using PaymentPlataform.Models;

namespace PaymentPlataform.Infra.Repositories.Wallets
{
    public interface IWalletRepository
    {
        Task AddAsync(Wallet wallet);
        void Update(Wallet wallet);
        Task<Wallet?> GetByDocumentOrEmail(string document, string email);
        ValueTask<Wallet?> GetById(int id);
        Task CommitAsync();
    }
}
