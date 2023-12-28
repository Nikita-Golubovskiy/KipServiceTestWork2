using System;
using SharedLayer.KipServiceTestWork.Interfaces;

using ModelObject = BusinessLogicLayer.KipServiceTestWork.Model.Log;
using DataTransferObject = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetLogInformation.Response;

namespace PresentationLayer.KipServiceTestWork.Cqrs.Converters.GetLogInformation;

/// <summary>
/// <see cref="ModelObject">ModelObject</see> repository parameter objects to <see cref="DataTransferObject">DataTransferObject</see> object converter.
/// </summary>
internal sealed class Converter : IDirectConverter<ModelObject, DataTransferObject>
{
    /// <summary>
    /// Request completion at date/time field.
    /// </summary>
    private readonly DateTimeOffset completionAt;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="completionAt">Request completion at date/time value.</param>
    public Converter(DateTimeOffset completionAt)
    {
        this.completionAt = completionAt;
    }

    /// <summary>
    /// Value conversion method.
    /// </summary>
    /// <param name="source">Source value to convert.</param>
    /// <returns>Result/converted value.</returns>
    public DataTransferObject Convert(ModelObject source)
    {
        if (source is null)
        {
            return null;
        }

        var result = new DataTransferObject(
            source.ID.ToString(),
            source.CalculateCompletionPercentage(this.completionAt),
            source.Response
        );

        return result;
    }
}