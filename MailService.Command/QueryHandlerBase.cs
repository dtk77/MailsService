using AutoMapper;
using MailsService.Data;
using MediatR;

namespace MailsService.Command
{
    /// <summary>
    /// Base class of all query handlers.
    /// </summary>
    public abstract class QueryHandlerBase : HandlerBase
    {
        protected QueryHandlerBase(
            IMediator mediator,
            MailsServiceDbContext context,
            IMapper mapper)
            : base(mediator, context, mapper)
        {
            context.ChangeTracker.QueryTrackingBehavior =
                Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
        }
    }
}
