using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NetflixApi.Domain.Movies.MovieHistories;
using NetflixApi.Domain.Shared;

namespace NetflixApi.Infrastructure.Configurations;


internal sealed class MovieHistoryConfigurations : IEntityTypeConfiguration<MovieHistory>
{
    public void Configure(EntityTypeBuilder<MovieHistory> builder)
    {
        builder.ToContainer("MovieHistories")
            .HasNoDiscriminator()
            .HasKey(c => new { c.UserId, c.MovieId } );

        builder.Property(c => c.Date)
            .HasConversion(
                n => n.Value,
                n => new WatchDate(n));
    }
}