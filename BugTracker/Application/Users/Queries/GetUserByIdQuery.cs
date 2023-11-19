using MediatR;

namespace BugTracker.Application.Users.Queries
{
	public record GetUserByIdQuery(Guid UserId) : IRequest<UserDto>;

	public record UserDto( Guid UserId, string UserName );

}
