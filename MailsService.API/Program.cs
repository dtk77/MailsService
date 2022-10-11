using MailsService.API.Extensions;
using MailsService.Command;
using MailsService.Data.Services;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigurationMail(builder.Configuration);
builder.Services.AddMediatR(typeof(HandlerBase));
builder.Services.AddAutoMapperProfiles();
builder.Services.AddTransient<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseEndpoints(endpoints => endpoints.MapControllers());;
app.MapControllers();

app.Run();
