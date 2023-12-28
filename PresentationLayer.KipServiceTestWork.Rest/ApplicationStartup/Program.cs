using Microsoft.AspNetCore.Builder;
using PresentationLayer.KipServiceTestWork.Rest.ApplicationStartup;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

var startupConfigurator = new StartupConfigurator(webApplicationBuilder);

startupConfigurator.ConfigureServices(webApplicationBuilder.Services);

var webApplication = webApplicationBuilder.Build();

startupConfigurator.Configure(webApplication, webApplicationBuilder.Environment);

webApplication.Run();