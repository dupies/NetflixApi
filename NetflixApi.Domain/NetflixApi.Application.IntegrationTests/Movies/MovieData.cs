using Docker.DotNet.Models;
using Microsoft.Azure.Cosmos.Core;
using NetflixApi.Application.Movies.AddMovie;
using NetflixApi.Domain.Shared;

namespace NetflixApi.Application.IntegrationTests.Movies;

internal class MovieData
{
    public static readonly AddMovieRequest MovieRequest = new AddMovieRequest(
        Id: 12345,
        Adult: false,
        Backdrop_path: "/example_backdrop.jpg",
        Genre_ids: new int[] { 28, 12, 14 },
        Original_language: "en",
        Original_title: "Example Original Title",
        Overview: "This is a sample overview of the movie.",
        Popularity: 8.5,
        Poster_path: "/example_poster.jpg",
        Release_date: new DateOnly(2023, 10, 15),
        Title: "Example Movie Title",
        Video: false,
        Vote_average: 7.9,
        Vote_count: 1000
    );
}
