using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CreateLogCommandResponse = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.CreateLog.Response;

using GetUserStatisticsQueryRequest = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetUserStatistics.Request;
using GetLogInformationQueryResponse = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetLogInformation.Response;

// ReSharper disable UnusedMember.Global

namespace PresentationLayer.KipServiceTestWork.Rest.V1.Interfaces;

/// <summary>
/// Reports controller interface.
/// </summary>
public interface IReportsController
{
    /// <summary>
    /// User statistics report calculation method.
    /// </summary>
    /// <param name="request">Corresponding request data context value.</param>
    /// <returns>Request ID value.</returns>
    Task<ActionResult<CreateLogCommandResponse>> CalculateUserStatisticsReport(GetUserStatisticsQueryRequest request
    );

    /// <summary>
    /// Get report information, matching <paramref name="requestID" /> value obtaining method.
    /// </summary>
    /// <param name="requestID">Request ID value.</param>
    /// <returns>Log information data response value.</returns>
    Task<ActionResult<GetLogInformationQueryResponse>> GetLogInformation(Guid requestID);
}