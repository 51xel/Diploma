using Diploma.Domain.Wallets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Dal.EntityFramework.Wallets.Configurations
{
    class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("wallet");

            builder.HasKey(wallet => wallet.UserId);

            builder
                .Property(wallet => wallet.UserId)
                .HasColumnName("userId")
                .IsRequired();

            builder
                .HasOne(wallet => wallet.User)
                .WithOne() 
                .HasForeignKey<Wallet>(wallet => wallet.UserId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder
                .Property(wallet => wallet.EncryptedApiKey)
                .HasColumnName("encryptedApiKey")
                .IsRequired()
                .HasMaxLength(512);

            builder
                .Property(wallet => wallet.Integration)
                .HasColumnName("integration")
                .HasConversion(new EnumToNumberConverter<Integration, int>())
                .IsRequired();
        }
    }
}
