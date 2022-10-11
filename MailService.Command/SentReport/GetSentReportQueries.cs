using AutoMapper;
using MailsService.Data;
using MailsService.Data.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MailsService.Command.SentReport
{
    public class GetAllSentReportQuery : IRequest<IEnumerable<SentReportDto>> { }

    public class SentQueryHandler 
        : QueryHandlerBase, IRequestHandler<GetAllSentReportQuery, IEnumerable<SentReportDto>>
    {
        public SentQueryHandler(
            IMediator mediator,
            MailsServiceDbContext context,
            IMapper mapper)
            : base(mediator, context, mapper)
        {
        }

        public async Task<IEnumerable<SentReportDto>> Handle(GetAllSentReportQuery request, CancellationToken cancellationToken)
        {
            return await Context.SentReport
                .Select(x=> Mapper.Map<SentReportDto>(x))
                .ToListAsync(cancellationToken);
        }
    }
}
