using Microsoft.EntityFrameworkCore.Storage;
using PaymentPlataform.Models;

namespace PaymentPlataform.Infra.Repositories.Transfers
{
    public class TransferRepository : ITransferRepository
    {
        private readonly ApplicationDbContext _context;

        public TransferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTransactionAsync(Transfer transfer)
        {
            await _context.Transfers.AddAsync(transfer);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
