using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MailsService.API.Controllers
{
    [ApiController]
    [Route("api/")]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Gets injected Mediator instance 
        /// </summary>
        protected IMediator Mediator { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
