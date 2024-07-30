using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(player => player.Email)
            .HasMaxLength(400)
            .HasConversion(email => email.Value, value => Email.Create(value).Value);

        builder.ComplexProperty(
            u => u.Name,
            b => b.Property(e => e.Value).HasColumnName("name"));

        builder.HasIndex(player => player.Email).IsUnique();

        builder.HasIndex(user => user.IdentityId).IsUnique();
    }
}
