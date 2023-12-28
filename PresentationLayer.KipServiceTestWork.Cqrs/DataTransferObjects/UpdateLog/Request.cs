using System;
using System.Runtime.Serialization;

namespace PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.UpdateLog;

/// <summary>
/// <see cref="Commands.UpdateLog.Execute(Request)">UpdateLog</see> command request describing DTO class.
/// </summary>
[DataContract]
public sealed class Request
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id">Log ID value.</param>
    /// <param name="jsonResponse">Log response value.</param>
    public Request(
        Guid id,
        string jsonResponse
    ) {
        this.ID = id;
        this.JsonResponse = jsonResponse;
    }

    /// <summary>
    /// Log ID property.
    /// </summary>
    [DataMember]
    public Guid ID { get; }

    /// <summary>
    /// Log response property.
    /// </summary>
    [DataMember]
    public string JsonResponse { get; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "ID: {0}, JsonResponse: {1}",
            this.ID,
            this.JsonResponse
        );
    }
}