using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _3T.Gestproj.RestApp.Controller
{
    [ApiController]
    //[ApiExceptionFilter]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
