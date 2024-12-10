using Microsoft.EntityFrameworkCore.Storage;
using PaymentPlataform.Models;

namespace PaymentPlataform.Infra.Repositories.Transfers
{
    public interface ITransferRepository
    {
        Task AddTransactionAsync(Transfer transfer);
        Task CommitAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
