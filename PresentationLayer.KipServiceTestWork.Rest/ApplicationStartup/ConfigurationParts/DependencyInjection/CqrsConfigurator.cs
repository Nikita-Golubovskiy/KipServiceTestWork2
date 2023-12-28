using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PresentationLayer.KipServiceTestWork.Cqrs.Commands;
using PresentationLayer.KipServiceTestWork.Cqrs.Interfaces.Command.Canonical;
using PresentationLayer.KipServiceTestWork.Rest.ApplicationStartup.Interfaces;
using PresentationLayer.KipServiceTestWork.Cqrs.Interfaces.Query.Parametric;
using PresentationLayer.KipServiceTestWork.Cqrs.Queries;
using PresentationLayer.KipServiceTestWork.Cqrs.Interfaces.Command.NonCanonical;

using CreateLogCommandRequest = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.CreateLog.Request;
using CreateLogCommandResponse = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.CreateLog.Response;

using UpdateLogCommandRequest = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.UpdateLog.Request;

using GetUserStatisticsQueryRequest = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetUserStatistics.Request;
using GetUserStatisticsQueryResponse = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetUserStatistics.Response;

using GetLogInformationQueryRequest = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetLogInformation.Request;
using GetLogInformationQueryResponse = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetLogInformation.Response;

namespace PresentationLayer.KipServiceTestWork.Rest.ApplicationStartup.ConfigurationParts.DependencyInjection;

/// <summary>
/// CQRS DI configuration startup class.
/// </summary>
internal sealed class CqrsConfigurator : IConfigurator
{
    /// <summary>
    /// Services collection setup/configuring method.
    /// </summary>
    /// <param name="servicesCollection">Services collection, which ones must to be configured, reference value.</param>
    public void ConfigureServices(IServiceCollection servicesCollection)
    {
        servicesCollection.AddScoped<
            IAsyncQuery<GetUserStatisticsQueryRequest, GetUserStatisticsQueryResponse>,
            GetUserStatistics
        >();

        servicesCollection.AddScoped<
            IAsyncQuery<GetLogInformationQueryRequest, GetLogInformationQueryResponse>,
            GetLogInformation
        >();

        servicesCollection.AddScoped<IAsyncCommand<CreateLogCommandRequest, CreateLogCommandResponse>, CreateLog>();
        servicesCollection.AddScoped<IAsyncCommand<UpdateLogCommandRequest>, UpdateLog>();
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