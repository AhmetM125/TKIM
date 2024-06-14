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
    public async Task<IActionResult> CreateCompany([FromBody]CompanyCreateVM command)
     => await HandleResponse(
         new CompanyCreateCommand(command.Name, command.Description
             , command.Address, command.PhoneNumber, command.Number,command.Email));

    [HttpGet("Get/All")]
    [ProducesResponseType((int)StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCompanies()
        => await HandleResponse(new CompanyGetAllQuery());

    [HttpGet("Get/Modify/{companyId}")]
    [ProducesResponseType((int)StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCompanyForModify(Guid companyId)
        => await HandleResponse(new CompanyModifyQuery(companyId));

    [HttpPut("Modify")]
    [ProducesResponseType((int)StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ModifyCompany([FromBody] CompanyUpdateVM command)
        => await HandleResponse(
                       new CompanyUpdateCommand(command.Id, command.Name, command.Description
                                          , command.Address, command.PhoneNumber, command.Number, command.Email));

    [HttpGet("dropdown")]
    [ProducesResponseType((int)StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCompanyForDropdown()
        => await HandleResponse(new CompanyDropdownQuery());
}
