using MediatR;
using Microsoft.AspNetCore.Mvc;
using TKIM.Api.Controllers.Base;
using TKIM.Application.Company;

namespace TKIM.Api.Controllers;

public class CompanyController : BaseController
{
    public CompanyController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("Create")]
    [ProducesResponseType((int)StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCompany(CompanyCreateVM command)
     => await HandleResponse(
         new CompanyCreateCommand(command.Name, command.Description
             , command.Address, command.PhoneNumber, command.Number,command.Email));
}
