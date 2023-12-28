using System;
using BusinessLogicLayer.KipServiceTestWork.Model.Exceptions;
using BusinessLogicLayer.KipServiceTestWork.Model.Interfaces;

using DomainErrors = BusinessLogicLayer.KipServiceTestWork.Model.Assets.Strings.Errors.Domain;

namespace BusinessLogicLayer.KipServiceTestWork.Model;

/// <summary>
/// Log model class.
/// </summary>
public class Log : IAggregationRoot
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id">Request ID value.</param>
    /// <param name="requestAt">Request at date/time value.</param>
    /// <param name="request">Request value.</param>
    /// <param name="response">Response value.</param>
    public Log(
        Guid id,
        DateTimeOffset requestAt,
        string request,
        string response
    ) {
        this.ID = id;
        this.RequestAt = requestAt;
        this.Request = request;
        this.Response = response;

        if (string.IsNullOrEmpty(this.Request))
        {
            throw new DomainModelException(DomainErrors.LOG_REQUEST_IS_MISSING);
        }
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="request">Request value.</param>
    public Log(string request) : this(
        Guid.NewGuid(),
        DateTimeOffset.Now,
        request,
        null
    ) {
    }

    /// <summary>
    /// Request ID property.
    /// </summary>
    public Guid ID { get; }

    /// <summary>
    /// Request at date/time property.
    /// </summary>
    public DateTimeOffset RequestAt { get; }

    /// <summary>
    /// Request property.
    /// </summary>
    public string Request { get; }

    /// <summary>
    /// Response property.
    /// </summary>
    public string Response { get; private set; }

    /// <summary>
    /// Completion percentage calculating method.
    /// </summary>
    /// <param name="completionAt">Completion at date/time value.</param>
    /// <returns>Completion percentage value.</returns>
    public int CalculateCompletionPercentage(DateTimeOffset completionAt)
    {
        const int maxCompletionPercent = 100;

        var dateNow = DateTimeOffset.Now;

        var processTime = (completionAt - this.RequestAt).TotalSeconds;

        var secondForOnePercent = processTime / maxCompletionPercent;

        var remainingTime = (completionAt - dateNow).TotalSeconds;

        if (remainingTime <= 0.0)
        {
            return maxCompletionPercent;
        }

        var resultToDouble = maxCompletionPercent - remainingTime * secondForOnePercent;

        var result = Convert.ToInt32(resultToDouble);

        return result > maxCompletionPercent ?
            maxCompletionPercent :
            result;
    }

    /// <summary>
    /// Response attaching method.
    /// </summary>
    /// <param name="response">Response value.</param>
    public void AttachResponse(string response)
    {
        this.Response = response;

        if (string.IsNullOrEmpty(this.Response))
        {
            throw new DomainModelException(DomainErrors.LOG_RESPONSE_IS_MISSING);
        }
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "ID: {0}, RequestAt: {1}, Request: {2}, Response: {3}",
            this.ID,
            this.RequestAt,
            this.Request,
            this.Response
        );
    }
}