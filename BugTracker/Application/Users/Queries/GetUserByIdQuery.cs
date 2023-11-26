using BugTracker.Application.Common;
using BugTracker.Application.Common.Services;
using BugTracker.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Application.Users.Queries;
public record UserDto(Guid UserId, string UserName);
public record GetUserByIdQuery(Guid UserId) : IRequest<Result<UserDto>>;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
    private BugTrackerDbContext _dbContext;
    private ILogger _logger;

    public GetUserByIdQueryHandler(BugTrackerDbContext dbContext, ILogger logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userDto = await _dbContext.Users
            .Where(u => u.UserId == request.UserId)
            .Select(u => new UserDto(u.UserId, $"{u.FirstName} {u.LastName}"))
            .FirstOrDefaultAsync(cancellationToken);

        _logger.LogInformation("This is your first Log.");

        return userDto == null
            ? Result<UserDto>.Failure("User not found.")
            : Result<UserDto>.Success(userDto);
    }

}


