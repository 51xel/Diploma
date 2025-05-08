using Diploma.Dal.EntityFramework.Common.Helpers;
using Diploma.Domain.Common.Models;
using Diploma.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diploma.Dal.EntityFramework.Models.Configurations
{
    class ModelConfigurations : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("model");

            builder.HasKey(model => model.Id);

            builder
                .Property(model => model.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(model => model.Name)
                .HasColumnName("name")
                .IsRequired();

            builder
                .Property(model => model.Type)
                .HasColumnName("type")
                .HasConversion<EnumToIntConverter<ModelType>>()
                .IsRequired();

            builder.OwnsOne(model => model.TrainingTime, trainingTime =>
            {
                trainingTime
                    .Property(t => t.Type)
                    .HasColumnName("timeRange")
                    .HasConversion<EnumToIntConverter<TimeRangeType>>()
                    .IsRequired();

                trainingTime
                    .Property(t => t.From)
                    .HasColumnName("from")
                    .IsRequired();

                trainingTime
                    .Property(t => t.To)
                    .HasColumnName("to")
                    .IsRequired();
            });
        }
    }
}
