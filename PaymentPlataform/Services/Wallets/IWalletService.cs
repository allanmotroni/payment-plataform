using PaymentPlataform.Models.Requests;
using PaymentPlataform.Models.Responses;

namespace PaymentPlataform.Services.Wallets;

public interface IWalletService
{
    Task<Result<bool>> ExecuteAsync(WalletRequest request);
    Task<IEnumerable<WalletResponse>> GetAsync();
}
