using System.Runtime.Serialization;

namespace PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetUserStatistics;

/// <summary>
/// <see cref="Queries.GetUserStatistics.Execute(Request)">GetUserStatistics</see> command response describing DTO class.
/// </summary>
[DataContract]
public sealed class Response
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="userID">User ID value.</param>
    /// <param name="countSignIn">User count sign in value.</param>
    public Response(
        string userID,
        int countSignIn
    ) {
        this.UserID = userID;
        this.CountSignIn = countSignIn;
    }

    /// <summary>
    /// User ID property.
    /// </summary>
    [DataMember]
    public string UserID { get; }

    /// <summary>
    /// User count sign in property.
    /// </summary>
    [DataMember]
    public int CountSignIn { get; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "UserID: {0}, CountSignIn: {1}",
            this.UserID,
            this.CountSignIn
        );
    }
}