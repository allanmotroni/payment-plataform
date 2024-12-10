using PaymentPlataform.Models.Requests;
using PaymentPlataform.Models.Responses;

namespace PaymentPlataform.Services.Transfers;

public interface ITransferService
{
    Task<Result<TransferResponse>> ExecuteAsync(TransferRequest request);
}
