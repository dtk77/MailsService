using AutoMapper;
using MailsService.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace MailsService.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<MailsServiceDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));


    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
        return services.AddSingleton(config.CreateMapper());
    }

    public static void ConfigurationMail(this IServiceCollection services, IConfiguration configuration) =>
        services.Configure<MailSetting>(configuration.GetSection("MailKitSettings"));

  
}
