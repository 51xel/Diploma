using Diploma.Dal.EntityFramework.Common.Helpers;
using Diploma.Domain.Actions;
using Diploma.Domain.Common.Models;
using Diploma.Domain.TradeActions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Dal.EntityFramework.TradeActions.Configurations
{
    class TradeActionConfiguration : IEntityTypeConfiguration<TradeAction>
    {
        public void Configure(EntityTypeBuilder<TradeAction> builder)
        {
            builder.ToTable("tradeAction");

            builder.HasKey(tradeAction => tradeAction.Id);

            builder
                .Property(tradeAction => tradeAction.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(tradeAction => tradeAction.ActAt)
                .HasColumnName("actAt")
                .IsRequired();

            builder
                .Property(tradeAction => tradeAction.Type)
                .HasColumnName("actionType")
                .HasConversion<EnumToIntConverter<TradeActionType>>()
                .IsRequired();

            builder
                .Property(tradeAction => tradeAction.PredictedPrice)
                .HasColumnName("predictedPrice")
                .IsRequired();

            builder
                .HasOne(tradeAction => tradeAction.Algorithm)
                .WithMany()
                .HasForeignKey("algorithmId")
                .IsRequired();
        }
    }
}
