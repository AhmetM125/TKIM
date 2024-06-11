using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TKIM.Application.Core.CQRS.CommandHandling;
using TKIM.Application.Core.CQRS.QueryHandling;

namespace TKIM.Api.Controllers.Base;

[Route("api/v{version}/[controller]")]
[ApiVersion("1.0")]
[ApiController]
[EnableCors("AllowOrigin")]

public class BaseController : ControllerBase
{
    private readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async new Task<IActionResult> HandleResponse<TResult>(Query<TResult> query)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var queryHandlerResult = await _mediator.Send(query);
            return queryHandlerResult.ValidationResult.IsValid
                ? OkActionResult(queryHandlerResult.Id)
                : BadRequestActionResult(queryHandlerResult.ValidationResult.Errors);
        }
        catch (Exception e)
        {
            return BadRequestActionResult(e.Message);
        }
    }

    protected async new Task<IActionResult> HandleResponse<TResult>(Command<TResult> command)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var commandHandlerResult = await _mediator.Send(command);
            return commandHandlerResult.ValidationResult.IsValid ? OkActionResult(commandHandlerResult.Id)
                : BadRequestActionResult(commandHandlerResult.ValidationResult.Errors);
        }
        catch (Exception e)
        {
            return BadRequestActionResult(e.Message);
        }
    }

    protected IActionResult BadRequestActionResult(dynamic resultErrors)
    {
        return BadRequest(new
        {
            success = false,
            message = resultErrors
        });
    }

    protected IActionResult OkActionResult(dynamic resultData)
    {
        return Ok(new
        {
            success = true,
            data = resultData
        });
    }
}
