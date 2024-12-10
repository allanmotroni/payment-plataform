using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PaymentPlataform.Models;

namespace PaymentPlataform.Infra.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder
                .ToTable("Wallet");

            builder
                .HasKey(p => p.Id);

            builder
                .HasIndex(p => new { p.Document, p.Email })
                .IsUnique();

            builder
                .Property(p => p.Id)
                .HasColumnName("id");

            builder
                .Property(p => p.Balance)
                .HasColumnName("balance")
                .HasColumnType("decimal(18, 2)");

            builder
                .Property(p => p.UserType)
                .HasColumnName("user_type")
                .HasConversion<string>();
        }
    }
}
