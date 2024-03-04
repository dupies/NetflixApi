
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NetflixApi.Domain.Movies;
using NetflixApi.Domain.Shared;

namespace NetflixApi.Infrastructure.Configurations;

internal sealed class MovieConfigurations : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToContainer("Movies")
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

        builder.Property(c => c.Title)
            .HasConversion(
                n => n.Value,
                n => new Title(n));

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

        builder.Property(c => c.Release_date)
            .HasConversion(
                n => n.Value,
                n => new Release_date(n));

        builder.Property(c => c.Original_title)
            .HasConversion(
                n => n.Value,
                n => new Original_title(n));

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
