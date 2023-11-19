using BugTracker.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private  readonly IMediator _mediator;

        public UserController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<UserDto>> GetUserById(Guid userId)
		{
			var user = await _mediator.Send(new GetUserByIdQuery(userId));
			return user == null ? NotFound() : Ok(user);
		}

	}
}
