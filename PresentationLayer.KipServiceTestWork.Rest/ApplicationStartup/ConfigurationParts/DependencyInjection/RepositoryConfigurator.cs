using BusinessLogicLayer.KipServiceTestWork.Repository.Interfaces;
using DataAccessLayer.KipServiceTestWork.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.KipServiceTestWork.Rest.ApplicationStartup.Interfaces;

namespace PresentationLayer.KipServiceTestWork.Rest.ApplicationStartup.ConfigurationParts.DependencyInjection;

/// <summary>
/// Repository/repositories DI configuration startup class.
/// </summary>
internal sealed class RepositoryConfigurator : IConfigurator
{
    /// <summary>
    /// Services collection setup/configuring method.
    /// </summary>
    /// <param name="servicesCollection">Services collection, which ones must to be configured, reference value.</param>
    public void ConfigureServices(IServiceCollection servicesCollection)
    {
        servicesCollection.AddScoped<ILogsRepository, LogsRepository>();
        servicesCollection.AddScoped<IUsersRepository, UsersRepository>();
    }

    /// <summary>
    /// Global application building method.
    /// </summary>
    /// <param name="applicationBuilder">Application request pipeline builder reference value.</param>
    /// <param name="webHostingEnvironment">Web hosting environment information provider reference value.</param>
    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostingEnvironment)
    {
    }
}