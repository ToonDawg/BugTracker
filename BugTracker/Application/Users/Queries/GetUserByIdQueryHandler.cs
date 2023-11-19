using MediatR;

namespace BugTracker.Application.Users.Queries
{
	public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
	{
		public Task<UserDto> Handle( GetUserByIdQuery request, CancellationToken cancellationToken )
		{
			var userDto = new UserDto(UserId: Guid.NewGuid(), UserName: "Tunoa Johnson");
			return Task.FromResult( userDto );
		}
	}
}
