using PaymentPlataform.Infra.Repositories.Wallets;
using PaymentPlataform.Models;
using PaymentPlataform.Models.Requests;
using PaymentPlataform.Models.Responses;

namespace PaymentPlataform.Services.Wallets;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<Result<bool>> ExecuteAsync(WalletRequest request)
    {
        var walletExists = await _walletRepository.GetByDocumentOrEmailAsync(request.Document, request.Email);

        if (walletExists is not null)
        {
            return Result<bool>.Failure("Wallet already exists");
        }

        var wallet = new Wallet(
            request.Fullname,
            request.Document,
            request.Email,
            request.Password,
            request.UserType,
            request.Balance);

        await _walletRepository.AddAsync(wallet);
        await _walletRepository.CommitAsync();

        return Result<bool>.Success(true);
    }

    public async Task<IEnumerable<WalletResponse>> GetAsync()
    {
        var wallets = await _walletRepository.GetAsync();

        return wallets.Select(p => new WalletResponse(
            p.Id,
            p.Fullname,
            p.Document,
            p.Email,
            p.UserType.ToString(),
            p.Balance));
    }
}
