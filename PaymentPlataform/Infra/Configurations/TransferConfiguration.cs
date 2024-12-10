using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PaymentPlataform.Models;

namespace PaymentPlataform.Infra.Configurations
{
    public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder
                .ToTable("Transfer");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName("id");

            builder
                .HasOne(p => p.Sender)
                .WithMany()
                .HasForeignKey(p => p.SenderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Sender");

            builder
                .Property(p => p.Value)
                .HasColumnName("value")
                .HasColumnType("decimal(18, 2)");

            builder
                .HasOne(p => p.Receiver)
                .WithMany()
                .HasForeignKey(p => p.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Receiver");
        }
    }
}
