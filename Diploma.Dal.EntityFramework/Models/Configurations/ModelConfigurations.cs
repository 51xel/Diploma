using Diploma.Dal.EntityFramework.Common.Helpers;
using Diploma.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Dal.EntityFramework.Models.Configurations
{
    internal class ModelConfigurations : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder
                .HasNoDiscriminator()
                .ToContainer("Models")
                .HasPartitionKey(model => model.Type)
                .HasKey(model => model.Id);

            builder
                .Property(model => model.Id)
                .ToJsonProperty("id")
                .IsRequired();

            builder
                .Property(model => model.Name)
                .ToJsonProperty("name")
                .IsRequired();

            builder
                .Property(model => model.Type)
                .ToJsonProperty("type")
                .HasConversion(ValueConverterHelper.GetConverterForModelType())
                .IsRequired();

            builder.OwnsOne(model => model.TrainingTime, trainingTime =>
            {
                trainingTime
                    .ToJsonProperty("trainingTime");

                trainingTime
                    .Property(t => t.Type)
                    .ToJsonProperty("timeRange")
                    .HasConversion(ValueConverterHelper.GetConverterForTrainingTimeRangeType())
                    .IsRequired();

                trainingTime
                    .Property(t => t.From)
                    .ToJsonProperty("from")
                    .IsRequired();

                trainingTime
                    .Property(t => t.To)
                    .ToJsonProperty("to")
                    .IsRequired();
            });
        }
    }
}
