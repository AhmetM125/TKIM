using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bordro.Application.Core.CQRS.CommandHandling;
using Bordro.Application.Core.CQRS.QueryHandling;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TKIM.Api.Controllers.Base
{
    [Route("api/v{version}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
