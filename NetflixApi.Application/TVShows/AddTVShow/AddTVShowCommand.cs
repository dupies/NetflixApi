using NetflixApi.Application.Abstractions.Messaging;

namespace NetflixApi.Application.TVShows.AddTVShow;

public record AddTVShowCommand(AddTVShowRequest request) : ICommand<int>;
