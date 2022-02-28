using Payment.Gateway.Api.Services;
using Payment.Gateway.Api.Client.Clients;
using Payment.Gateway.Api.Components.Dtos;
using Payment.Gateway.Api.Client.Interfaces;
using Payment.Gateway.Api.Controllers.Middleware;
using Payment.Gateway.Api.Components.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddSwaggerGen();
services.AddControllers();
services.AddEndpointsApiExplorer();

var cfg = builder.Configuration.GetSection(nameof(Config)).Get<Config>();

services.AddAutoMapper(typeof(Program).Assembly);
services.AddSingleton<IPaymentService, PaymentService>();
services.AddHttpClient<IPaymentClient, PaymentClient>(cl => cl.BaseAddress = new Uri(cfg.CkoBankUrl));

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
