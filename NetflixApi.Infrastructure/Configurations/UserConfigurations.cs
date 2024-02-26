using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixApi.Domain.Shared;
using NetflixApi.Domain.TVShows;
using NetflixApi.Domain.Users;

namespace NetflixApi.Infrastructure.Configurations;

internal sealed class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToContainer("Users")
            .HasNoDiscriminator()
            .HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasConversion(
                n => n.Value,
                n => new Name(n));

        builder.Property(c => c.AvatarId)
            .HasConversion(
                n => n.Value,
                n => new AvatarId(n));

        builder.Property(c => c.ImageUrl)
            .HasConversion(
                n => n.Value,
                n => new ImageUrl(n));
    }
}
