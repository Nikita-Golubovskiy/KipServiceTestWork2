using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.KipServiceTestWork.Rest.ApplicationStartup.Interfaces;

namespace PresentationLayer.KipServiceTestWork.Rest.ApplicationStartup.ConfigurationParts;

/// <summary>
/// Versioning API configuration startup class.
/// </summary>
internal sealed class VersioningApiConfigurator : IConfigurator
{
    /// <summary>
    /// Services collection setup/configuring method.
    /// </summary>
    /// <param name="servicesCollection">Services collection, which ones must to be configured, reference value.</param>
    public void ConfigureServices(IServiceCollection servicesCollection)
    {
        servicesCollection.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;

            options.AssumeDefaultVersionWhenUnspecified = true;

            options.DefaultApiVersion = new ApiVersion(1, 0);
        });

        servicesCollection.AddVersionedApiExplorer(options =>
        {
            // ReSharper disable once StringLiteralTypo
            options.GroupNameFormat = "'v'VVV";

            options.SubstituteApiVersionInUrl = true;
        });
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