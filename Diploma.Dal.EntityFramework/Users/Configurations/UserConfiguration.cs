using Diploma.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diploma.Dal.EntityFramework.Users.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(user => user.Id);

            builder
                .Property(user => user.Id)
                .HasColumnName("id")
                .IsRequired();

            builder
                .Property(user => user.UserName)
                .HasColumnName("username")
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(user => user.AuthenticationTypes)
                .HasColumnName("authenticationTypes")
                .HasConversion(new EnumToNumberConverter<AuthenticationType, int>())
                .IsRequired();
        }
    }
}
