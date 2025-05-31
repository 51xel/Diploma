using Diploma.Domain.Users.AuthenticationTypes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Dal.EntityFramework.Users.Configurations
{
    class EmailAndPasswordAuthTypeConfiguration : IEntityTypeConfiguration<EmailAndPasswordAuthType>
    {
        public void Configure(EntityTypeBuilder<EmailAndPasswordAuthType> builder)
        {
            builder.ToTable("email_password_auth");

            builder.HasKey(e => e.UserId);

            builder
                .Property(e => e.UserId)
                .HasColumnName("userId")
                .IsRequired();

            builder
                .Property(e => e.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(e => e.PasswordHash)
                .HasColumnName("passwordHash")
                .IsRequired();
        }
    }
}
