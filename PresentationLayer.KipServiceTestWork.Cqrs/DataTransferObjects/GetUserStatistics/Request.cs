using System;
using System.Runtime.Serialization;

namespace PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetUserStatistics;

/// <summary>
/// <see cref="Queries.GetUserStatistics.Execute(Request)">GetUserStatistics</see> command request describing DTO class.
/// </summary>
[DataContract]
public sealed class Request
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userID">User ID value.</param>
    /// <param name="from">Period from date/time value.</param>
    /// <param name="to">Period to date/time value.</param>
    public Request(
        Guid userID,
        DateTimeOffset from,
        DateTimeOffset to
    ) {
        this.UserID = userID;
        this.From = from;
        this.To = to;
    }

    /// <summary>
    /// User ID property.
    /// </summary>
    [DataMember]
    public Guid UserID { get; }

    /// <summary>
    /// Period from date/time property.
    /// </summary>
    [DataMember]
    public DateTimeOffset From { get; }

    /// <summary>
    /// Period to date/time property.
    /// </summary>
    [DataMember]
    public DateTimeOffset To { get; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "UserID: {0}, From: {1}, To: {2}",
            this.UserID,
            this.From,
            this.To
        );
    }
}