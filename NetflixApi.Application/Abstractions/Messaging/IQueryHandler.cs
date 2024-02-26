using MediatR;
using NetflixApi.Domain.Abstractions;

namespace NetflixApi.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}