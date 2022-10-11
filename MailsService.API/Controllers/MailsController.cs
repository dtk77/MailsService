using MailsService.Command.SentReport;
using MailsService.Data.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MailsService.API.Controllers
{
    /// <summary>
    /// Controller for SentReport APIs 
    /// </summary>
    public class MailsController : BaseController
    {
        public MailsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("getlog")]
        public async Task<ActionResult<IEnumerable<SentReportDto>>> GetAllSentReports()
        {
            return Ok(await Mediator.Send(new GetAllSentReportQuery()));
        }

        [HttpPost]
        [Route("mails")]
        public async Task<ActionResult> CreateSendTask([FromBody] TaskForSendDto dto)
        {
            return Ok(await Mediator.Send(
                new CreateSentReportCommand() { TaskForSendDto = dto }));
        }
    }
}
