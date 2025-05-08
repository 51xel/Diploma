using Diploma.Domain.Actions;
using Diploma.Domain.TradeActions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Dal.EntityFramework.TradeActions.Configurations
{
    class TradePairConfiguration : IEntityTypeConfiguration<TradePair>
    {
        public void Configure(EntityTypeBuilder<TradePair> builder)
        {
            builder.ToTable("tradePair");

            builder.HasKey(tradePair => tradePair.Id);

            builder
                .Property(tradePair => tradePair.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .HasOne(tradePair => tradePair.BuyAction)
                .WithMany()
                .HasForeignKey("buyActionId")
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(tradePair => tradePair.SellAction)
                .WithMany()
                .HasForeignKey("sellActionId")
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
