using PaymentPlataform.Models;

namespace PaymentPlataform.Infra.Repositories.Wallets
{
    public interface IWalletRepository
    {
        Task AddAsync(Wallet wallet);
        void Update(Wallet wallet);
        Task<IEnumerable<Wallet>> GetAsync();
        Task<Wallet?> GetByDocumentOrEmailAsync(string document, string email);
        ValueTask<Wallet?> GetByIdAsync(int id);
        Task CommitAsync();
    }
}
