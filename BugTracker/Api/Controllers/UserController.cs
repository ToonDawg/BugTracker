using BugTracker.Api.Common;
using BugTracker.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUserById(Guid userId)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(userId));
            return HandleResult(result);
        }

    }
}
