using FluentAssertions;
using NetflixApi.Application.IntegrationTests.Infrastructure;
using NetflixApi.Application.Movies.AddMovie;
using NetflixApi.Application.Movies.GetMovies;
using NetflixApi.Domain.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixApi.Application.IntegrationTests.Movies;

public class MovieTests : BaseIntegrationTest
{
    public MovieTests(IntegrationTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task GetMovie_WithWrongId_ShouldReturnNotFound()
    {
        // Arrange
        var query = new GetMovieQuery(1);

        // Act
        var result = await Sender.Send(query);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(MovieErrors.NotFound);
    }

    [Fact]
    public async Task AddMovie_ShouldCreateMovie()
    {
        // Arrange
        var command = new AddMovieCommand(MovieData.MovieRequest);

        // Act
        var result = await Sender.Send(command);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(MovieData.MovieRequest.Id);
    }
}
