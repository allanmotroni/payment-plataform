using Microsoft.EntityFrameworkCore;
using PaymentPlataform.Models;

namespace PaymentPlataform.Infra.Repositories.Wallets
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationDbContext _context;
        public WalletRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
        }

        public void Update(Wallet wallet)
        {
            _context.Update(wallet);
        }

        public async ValueTask<Wallet?> GetById(int id)
        {
            return await _context.Wallets
                .FindAsync(id);
        }

        public async Task<Wallet?> GetByDocumentOrEmail(string document, string email)
        {
            return await _context.Wallets
                .FirstOrDefaultAsync(wallet => 
                wallet.Document.Equals(document) || 
                wallet.Email.Equals(email));
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
