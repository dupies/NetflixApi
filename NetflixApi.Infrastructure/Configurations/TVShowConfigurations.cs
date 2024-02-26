using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixApi.Domain.Shared;
using NetflixApi.Domain.TVShows;

namespace NetflixApi.Infrastructure.Configurations;

internal sealed class TVShowConfigurations : IEntityTypeConfiguration<TVShow>
{
    public void Configure(EntityTypeBuilder<TVShow> builder)
    {
        builder.ToContainer("TVShows")
            .HasNoDiscriminator()
            .HasKey(c => c.Id);

        builder.Property(c => c.Backdrop_path)
            .HasConversion(
                n => n.Value,
                n => new Backdrop_path(n));

        builder.Property(c => c.Original_language)
            .HasConversion(
                n => n.Value,
                n => new Original_language(n));

        builder.Property(c => c.Original_name)
            .HasConversion(
                n => n.Value,
                n => new Name(n));

        builder.Property(c => c.Overview)
            .HasConversion(
                n => n.Value,
                n => new Overview(n));

        builder.Property(c => c.Popularity)
            .HasConversion(
                n => n.Value,
                n => new Popularity(n));

        builder.Property(c => c.Poster_path)
            .HasConversion(
                n => n.Value,
                n => new Poster_path(n));

        builder.Property(c => c.First_air_date)
            .HasConversion(
                n => n.Value,
                n => new First_air_date(n));

        builder.Property(c => c.Name)
            .HasConversion(
                n => n.Value,
                n => new Name(n));

        builder.Property(c => c.Vote_average)
            .HasConversion(
                n => n.Value,
                n => new Vote_average(n));

        builder.Property(c => c.Vote_count)
            .HasConversion(
                n => n.Value,
                n => new Vote_count(n));
    }
}
