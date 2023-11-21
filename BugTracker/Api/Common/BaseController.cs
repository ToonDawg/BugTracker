using BugTracker.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Common;

public abstract class BaseController : ControllerBase
{
    protected ActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return result.Value == null ? NotFound() : Ok(result.Value);
        }
        return BadRequest(result.Errors);
    }
}

