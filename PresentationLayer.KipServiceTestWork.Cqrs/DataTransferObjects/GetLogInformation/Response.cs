using System.Runtime.Serialization;

namespace PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetLogInformation;

/// <summary>
/// <see cref="Queries.GetLogInformation.Execute(Request)">GetLogInformation</see> command response describing DTO class.
/// </summary>
[DataContract]
public sealed class Response
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logID">Log ID value.</param>
    /// <param name="percent">Log percent value.</param>
    /// <param name="result">Log result value.</param>
    public Response(
        string logID,
        int percent,
        string result
    ) {
        this.LogID = logID;
        this.Percent = percent;
        this.Result = result;
    }

    /// <summary>
    /// Log ID property.
    /// </summary>
    [DataMember]
    public string LogID { get; }

    /// <summary>
    /// Log percent property.
    /// </summary>
    [DataMember]
    public int Percent { get; }

    /// <summary>
    /// Log result property.
    /// </summary>
    [DataMember]
    public string Result { get; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "LogID: {0}, Percent: {1}, Result: {2}",
            this.LogID,
            this.Percent,
            this.Result
        );
    }
}