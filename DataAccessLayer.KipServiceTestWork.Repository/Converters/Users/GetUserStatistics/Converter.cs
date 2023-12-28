using System.Collections.Generic;
using System.Linq;
using SharedLayer.KipServiceTestWork.Interfaces;

using EntityObject = DataAccessLayer.KipServiceTestWork.Database.Entities.UserSign;
using ParameterObject = BusinessLogicLayer.KipServiceTestWork.Repository.ParameterObjects.IUsersRepository.GetUserStatistics.UserStatisticsData;

namespace DataAccessLayer.KipServiceTestWork.Repository.Converters.Users.GetUserStatistics;

/// <summary>
/// <see cref="EntityObject">EntityObject</see> repository parameter objects to <see cref="ParameterObject">ParameterObject</see> object converter.
/// </summary>
internal sealed class Converter : IDirectConverter<ICollection<EntityObject>, ParameterObject>
{
    /// <summary>
    /// Value conversion method.
    /// </summary>
    /// <param name="source">Source value to convert.</param>
    /// <returns>Result/converted value.</returns>
    public ParameterObject Convert(ICollection<EntityObject> source)
    {
        if (source is null)
        {
            return null;
        }

        var userID = source
            .Select(userSign => userSign.UserID)
            .Distinct()
            .FirstOrDefault();

        var result = new ParameterObject(
            // ReSharper disable once PossibleInvalidOperationException
            userID.Value,
            source.Count
        );

        return result;
    }
}