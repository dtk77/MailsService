using MailsService.Data;
using MediatR;
using AutoMapper;

namespace MailsService.Command
{
    public abstract class HandlerBase
    {
        protected HandlerBase(IMediator mediator, MailsServiceDbContext context, IMapper mapper)
        {
            Mediator = mediator;
            Context = context;
            Mapper = mapper;
        }

        protected IMediator Mediator { get; }
        protected MailsServiceDbContext Context { get; }
        protected IMapper Mapper { get; }

       

    }
}
