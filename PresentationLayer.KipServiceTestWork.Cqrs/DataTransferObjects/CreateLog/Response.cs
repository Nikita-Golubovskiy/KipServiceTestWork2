using System.Runtime.Serialization;

namespace PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.CreateLog;

/// <summary>
/// <see cref="Commands.CreateLog.Execute(Request)">CreateLog</see> command response describing DTO class.
/// </summary>
[DataContract]
public sealed class Response
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id">Log ID value.</param>
    public Response(string id)
    {
        this.ID = id;
    }

    /// <summary>
    /// Log ID property.
    /// </summary>
    [DataMember]
    public string ID { get; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format("ID: {0}", this.ID);
    }
}