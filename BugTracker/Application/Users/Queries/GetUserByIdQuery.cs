using BugTracker.Infrastructure.Data.Context;
using MediatR;

namespace BugTracker.Application.Users.Queries;
public record UserDto(Guid UserId, string UserName);
public record GetUserByIdQuery(Guid UserId) : IRequest<UserDto>;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private BugTrackerDbContext _dbContext;

    public GetUserByIdQueryHandler(BugTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userDto = await _dbContext.Users.FindAsync(request.UserId, cancellationToken);
        if (userDto == null)
        {
            return null;
        }
        return new UserDto(UserId: userDto.UserId, UserName: $"{userDto.FirstName} {userDto.LastName}");
    }
}


