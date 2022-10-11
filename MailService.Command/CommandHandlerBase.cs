using AutoMapper;
using MailsService.Data;
using MediatR;

namespace MailsService.Command
{
    /// <summary>
	/// Base class of all command handlers.
	/// </summary>
    public abstract class CommandHandlerBase : HandlerBase
    {
        protected CommandHandlerBase(
            IMediator mediator,
            MailsServiceDbContext context,
            IMapper mapper)
            : base(mediator, context, mapper)
        {
        }
    }
}
