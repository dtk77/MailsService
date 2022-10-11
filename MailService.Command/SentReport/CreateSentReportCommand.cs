using AutoMapper;
using MailsService.Data;
using MailsService.Data.DTOs;
using MailsService.Data.Services;
using MediatR;

namespace MailsService.Command.SentReport;

public class CreateSentReportCommand : IRequest<TaskForSendDto>
{
    public TaskForSendDto TaskForSendDto { get; set; }
}

public class CreateSentReportCommandHandler : CommandHandlerBase,
    IRequestHandler<CreateSentReportCommand, TaskForSendDto>
{
    private readonly IEmailService emailService;
    public CreateSentReportCommandHandler(
        IMediator mediator,
        MailsServiceDbContext context,
        IMapper mapper,
        IEmailService emailService)
        : base(mediator, context, mapper)
    {
        this.emailService = emailService;
    }

    public Task<TaskForSendDto> Handle(CreateSentReportCommand request, CancellationToken cancellationToken)
    {
        var dto = request.TaskForSendDto;
        var dtNow = DateTime.Now;

        foreach (var recipient in dto.recipients)
        {

            var resultSend = emailService.SendEmailAsync(
                toName: "",
                toAddress: recipient,
                subject: dto.Subject,
                bodyText: dto.Body);


            var model = new SentReportDto()
            {
                Subject = dto.Subject,
                Body = dto.Body,
                Email = recipient,
                Result = resultSend.Result.Item1,
                FailedMassage = resultSend.Result.Item2,
                SentDate = dtNow
            };

            var result = Mapper.Map<Model.Entities.SentReport>(model);

            Context.SentReport.Add(result);
            Context.SaveChanges();
        }
        return Task.FromResult(dto);
    }

}
