using System;
using System.Runtime.Serialization;

namespace PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetLogInformation;

/// <summary>
/// <see cref="Queries.GetLogInformation.Execute(Request)">GetLogInformation</see> command request describing DTO class.
/// </summary>
[DataContract]
public sealed class Request
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logID">Log ID value.</param>
    /// <param name="delaySecond">Request delay second value.</param>
    public Request(
        Guid logID,
        int delaySecond
    ) {
        this.LogID = logID;
        this.DelaySecond = delaySecond;
    }

    /// <summary>
    /// Log ID property.
    /// </summary>
    [DataMember]
    public Guid LogID { get; }

    /// <summary>
    /// Request delay second property.
    /// </summary>
    [DataMember]
    public int DelaySecond { get; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "LogID: {0}, DelaySecond: {1}",
            this.LogID,
            this.DelaySecond
        );
    }
}