using AutoMapper;
using MailsService.Model.Entities;
using MailsService.Data.DTOs;

namespace MailsService.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SentReport, SentReportDto>()
                .ForMember(dest => dest.Subject,
                    opt => opt.MapFrom(src => src.Message.Subject))
                .ForMember(dest => dest.Body,
                    opt => opt.MapFrom(src => src.Message.Body))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.Recipient.Email))
                .ForMember(dest => dest.Result,
                    opt => opt.MapFrom(src => src.MessageStatus.Result))
                .ForMember(dest => dest.FailedMassage,
                    opt => opt.MapFrom(src => src.MessageStatus.FailedMassage))
                .ForMember(dest => dest.SentDate,
                    opt => opt.MapFrom(src => src.MessageStatus.SentDate));


            CreateMap<SentReportDto, SentReport>()
                .ForPath(dest => dest.Message.Subject,
                    opt => opt.MapFrom(src => src.Subject))
                .ForPath(dest => dest.Message.Body,
                    opt => opt.MapFrom(src => src.Body))
                .ForPath(dest => dest.Recipient.Email,
                    opt => opt.MapFrom(src => src.Email))
                .ForPath(dest => dest.MessageStatus.Result,
                    opt => opt.MapFrom(src => src.Result))
                .ForPath(dest => dest.MessageStatus.FailedMassage,
                    opt => opt.MapFrom(src => src.FailedMassage))
                .ForPath(dest => dest.MessageStatus.SentDate,
                    opt => opt.MapFrom(src => src.SentDate));
        }
    }
}
