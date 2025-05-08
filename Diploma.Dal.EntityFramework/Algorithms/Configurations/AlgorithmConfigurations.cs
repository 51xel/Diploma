using Diploma.Dal.EntityFramework.Common.Helpers;
using Diploma.Domain.Algorithms;
using Diploma.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Dal.EntityFramework.Algorithms.Configurations
{
    class AlgorithmConfigurations : IEntityTypeConfiguration<Algorithm>
    {
        public void Configure(EntityTypeBuilder<Algorithm> builder)
        {
            builder.ToTable("algorithm");

            builder.HasKey(algorithm => algorithm.Id);

            builder
                .Property(algorithm => algorithm.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(algorithm => algorithm.Type)
                .HasColumnName("type")
                .HasConversion<EnumToIntConverter<AlgorithmType>>()
                .IsRequired();

            builder
                .HasMany(algorithm => algorithm.Models)
                .WithMany(model => model.Algorithms)
                .UsingEntity<Dictionary<string, object>>(
                    "algorithm_model",
                    j => j.HasOne<Model>()
                          .WithMany()
                          .HasForeignKey("modelId")
                          .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Algorithm>()
                          .WithMany()
                          .HasForeignKey("algorithmId")
                          .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}
