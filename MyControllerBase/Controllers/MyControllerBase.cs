using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CommonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyControllerBase : ControllerBase
    {
        private IMediator? mediator;
        protected IMediator? _mediator => mediator ?? (mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}
