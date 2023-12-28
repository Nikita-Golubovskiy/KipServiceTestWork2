using System.Runtime.Serialization;

namespace PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.CreateLog;

/// <summary>
/// <see cref="Commands.CreateLog.Execute(Request)">CreateLog</see> command request describing DTO class.
/// </summary>
[DataContract]
public sealed class Request
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="jsonRequest">Log request value.</param>
    public Request(string jsonRequest)
    {
        this.JsonRequest = jsonRequest;
    }

    /// <summary>
    /// Log request property.
    /// </summary>
    [DataMember]
    public string JsonRequest { get; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format("JsonRequest: {0}", this.JsonRequest);
    }
}