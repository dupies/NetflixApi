using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NetflixApi.Domain.WatchHistories;
using NetflixApi.Domain.Shared;

namespace NetflixApi.Infrastructure.Configurations;

internal sealed class WatchHistoryConfigurations : IEntityTypeConfiguration<WatchHistory>
{
    public void Configure(EntityTypeBuilder<WatchHistory> builder)
    {
        builder.ToContainer("WatchHistories")
            .HasNoDiscriminator()
            .HasKey(c => c.Id);;

        builder.Property(c => c.Date)
            .HasConversion(
                n => n.Value,
                n => new WatchDate(n));
    }
}