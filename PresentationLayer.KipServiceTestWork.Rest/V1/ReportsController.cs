using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.KipServiceTestWork.Rest.V1.Interfaces;
using PresentationLayer.KipServiceTestWork.Cqrs.Interfaces.Command.Canonical;
using System.ComponentModel.DataAnnotations;
using PresentationLayer.KipServiceTestWork.Cqrs.Interfaces.Query.Parametric;
using PresentationLayer.KipServiceTestWork.Cqrs.Interfaces.Command.NonCanonical;

using CreateLogCommandRequest = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.CreateLog.Request;
using CreateLogCommandResponse = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.CreateLog.Response;

using UpdateLogCommandRequest = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.UpdateLog.Request;

using GetUserStatisticsQueryRequest = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetUserStatistics.Request;
using GetUserStatisticsQueryResponse = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetUserStatistics.Response;

using GetLogInformationQueryRequest = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetLogInformation.Request;
using GetLogInformationQueryResponse = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetLogInformation.Response;
using Microsoft.Extensions.Configuration;

// ReSharper disable NotAccessedField.Local

namespace PresentationLayer.KipServiceTestWork.Rest.V1;

/// <summary>
/// Reports controller class.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}")]
public sealed class ReportsController : ControllerBase, IReportsController
{
    /// <summary>
    /// New log creating command DI reference field.
    /// </summary>
    private readonly IAsyncCommand<CreateLogCommandRequest, CreateLogCommandResponse> createLogCommand;

    /// <summary>
    /// Existing log update command DI reference field.
    /// </summary>
    private readonly IAsyncCommand<UpdateLogCommandRequest> updateLogCommand;

    /// <summary>
    /// User statistic providing query DI reference field.
    /// </summary>
    private readonly IAsyncQuery<GetUserStatisticsQueryRequest, GetUserStatisticsQueryResponse> getUserStatisticsCommand;

    /// <summary>
    /// Log information providing query DI reference field.
    /// </summary>
    private readonly IAsyncQuery<GetLogInformationQueryRequest, GetLogInformationQueryResponse> getLogInformationCommand;

    /// <summary>
    /// Project configuration provider DI reference field.
    /// </summary>
    private readonly IConfiguration configuration;

    /// <summary>
    /// Main constructor.
    /// </summary>
    /// <param name="createLogCommand">New log creating command reference value, obtaining from DI.</param>
    /// <param name="updateLogCommand">Existing log update command reference value, obtaining from DI.</param>
    /// <param name="getUserStatisticsCommand">User statistic providing query reference value, obtaining from DI.</param>
    /// <param name="getLogInformationCommand">Log information providing query reference value, obtaining from DI.</param>
    /// <param name="configuration">Project configuration provider reference value, obtaining from DI.</param>
    public ReportsController(
        IAsyncCommand<CreateLogCommandRequest, CreateLogCommandResponse> createLogCommand,
        IAsyncCommand<UpdateLogCommandRequest> updateLogCommand,
        IAsyncQuery<GetUserStatisticsQueryRequest, GetUserStatisticsQueryResponse> getUserStatisticsCommand,
        IAsyncQuery<GetLogInformationQueryRequest, GetLogInformationQueryResponse> getLogInformationCommand,
        IConfiguration configuration
    ) {
        this.createLogCommand = createLogCommand;
        this.updateLogCommand = updateLogCommand;
        this.getUserStatisticsCommand = getUserStatisticsCommand;
        this.getLogInformationCommand = getLogInformationCommand;
        this.configuration = configuration;
    }

    /// <summary>
    /// User statistics report calculation method.
    /// </summary>
    /// <param name="request">Corresponding request data context value.</param>
    /// <returns>Request ID value.</returns>
    [HttpPost]
    [Route("report/user_statistics")]
    public async Task<ActionResult<CreateLogCommandResponse>> CalculateUserStatisticsReport(
        [Required][FromBody] GetUserStatisticsQueryRequest request
    ) {
        var requestToJson = Newtonsoft.Json.JsonConvert.SerializeObject(request);

        var createLogRequest = new CreateLogCommandRequest(requestToJson);

        var result = await this.createLogCommand.Execute(createLogRequest);

        var delaySecond = this.configuration.GetValue<int>("DelaySecond");

        var delayTime = new TimeSpan(0, 0, 0, delaySecond);

        var task = Task.Delay(delayTime)
            .ContinueWith(async _ =>
            {
                var getUserStatistics = await this.getUserStatisticsCommand.Execute(request);

                var responseToJson = Newtonsoft.Json.JsonConvert.SerializeObject(getUserStatistics);

                var updateLogRequest = new UpdateLogCommandRequest(
                    Guid.Parse(result.ID),
                    responseToJson
                );

                await this.updateLogCommand.Execute(updateLogRequest);
            });

        Task.Run(async () => await task);

        return result;
    }

    /// <summary>
    /// Get report information, matching <paramref name="requestID" /> value obtaining method.
    /// </summary>
    /// <param name="requestID">Request ID value.</param>
    /// <returns>Log information data response value.</returns>
    [HttpGet]
    [Route("report/{requestID:guid}/info")]
    public async Task<ActionResult<GetLogInformationQueryResponse>> GetLogInformation(
        [Required] Guid requestID
    ) {
        var delaySecond = this.configuration.GetValue<int>("DelaySecond");

        var queryRequest = new GetLogInformationQueryRequest(
            requestID,
            delaySecond
        );

        return await this.getLogInformationCommand.Execute(queryRequest);
    }
}