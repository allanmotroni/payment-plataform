using PaymentPlataform.Infra.Repositories.Transfers;
using PaymentPlataform.Infra.Repositories.Wallets;
using PaymentPlataform.Mappers;
using PaymentPlataform.Models;
using PaymentPlataform.Models.Requests;
using PaymentPlataform.Models.Responses;
using PaymentPlataform.Services.Authorizers;
using PaymentPlataform.Services.Notifications;

namespace PaymentPlataform.Services.Transfers;

public class TransferService : ITransferService
{
    private readonly ILogger<TransferService> _logger;
    private readonly ITransferRepository _transferRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly IAuthorizerService _authorizerService;
    private readonly INotificationService _notificationService;

    public TransferService(
        ILogger<TransferService> logger,
        ITransferRepository transferRepository,
        IWalletRepository walletRepository,
        IAuthorizerService authorizerService,
        INotificationService notificationService)
    {
        _logger = logger;
        _transferRepository = transferRepository;
        _walletRepository = walletRepository;
        _authorizerService = authorizerService;
        _notificationService = notificationService;
    }

    public async Task<Result<TransferResponse>> ExecuteAsync(TransferRequest request)
    {
        if (!await _authorizerService.AuthorizerAsync())
        {
            return Result<TransferResponse>.Failure("Not authorized");
        }

        var sender = await _walletRepository.GetByIdAsync(request.SenderId);
        if (sender is null)
        {
            return Result<TransferResponse>.Failure("Sender not found");
        }

        if (sender.Balance == 0 || sender.Balance < request.Value)
        {
            return Result<TransferResponse>.Failure("Sender balance not enough");
        }

        if (sender?.UserType == Models.Enums.UserType.Store)
        {
            return Result<TransferResponse>.Failure("Wallet Store cannot tranfer");
        }

        var receiver = await _walletRepository.GetByIdAsync(request.ReceiverId);
        if (receiver is null)
        {
            return Result<TransferResponse>.Failure("Receiver not found");
        }

        sender!.Debit(request.Value);
        receiver!.Credit(request.Value);

        var transfer = new Transfer(request.SenderId, request.ReceiverId, request.Value);

        using (var transactionScope = await _transferRepository.BeginTransactionAsync())
        {
            try
            {
                _walletRepository.Update(sender);
                _walletRepository.Update(receiver);
                await _walletRepository.CommitAsync();

                await _transferRepository.AddTransactionAsync(transfer);
                await _transferRepository.CommitAsync();

                await transactionScope.CommitAsync();
            }
            catch (Exception ex)
            {
                await transactionScope.RollbackAsync();

                _logger.LogError(ex, ex.Message);

                return Result<TransferResponse>.Failure("Error tranfer");
            }

            await _notificationService.SendAsync();

            return Result<TransferResponse>.Success(transfer.ToTransferResponse());
        }
    }
}
