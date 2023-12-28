using SharedLayer.KipServiceTestWork.Interfaces;

using ParameterObject = BusinessLogicLayer.KipServiceTestWork.Repository.ParameterObjects.IUsersRepository.GetUserStatistics.UserStatisticsData;
using DataTransferObject = PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetUserStatistics.Response;

namespace PresentationLayer.KipServiceTestWork.Cqrs.Converters.GetUserStatistics;

/// <summary>
/// <see cref="ParameterObject">ParameterObject</see> repository parameter objects to <see cref="DataTransferObject">DataTransferObject</see> object converter.
/// </summary>
internal sealed class Converter : IDirectConverter<ParameterObject, DataTransferObject>
{
    /// <summary>
    /// Value conversion method.
    /// </summary>
    /// <param name="source">Source value to convert.</param>
    /// <returns>Result/converted value.</returns>
    public DataTransferObject Convert(ParameterObject source)
    {
        if (source is null)
        {
            return null;
        }

        var result = new DataTransferObject(
            source.ID.ToString(),
            source.CountSignIn
        );

        return result;
    }
}