using MediatR;
using NetflixApi.Domain.Abstractions;

namespace NetflixApi.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}