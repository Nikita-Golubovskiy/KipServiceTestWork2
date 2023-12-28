using System;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.KipServiceTestWork.Repository.Interfaces;
using DataAccessLayer.KipServiceTestWork.Database.Contexts;
using Microsoft.EntityFrameworkCore;

using GetUserStatisticsData = BusinessLogicLayer.KipServiceTestWork.Repository.ParameterObjects.IUsersRepository.GetUserStatistics.UserStatisticsData;

namespace DataAccessLayer.KipServiceTestWork.Repository;

/// <summary>
/// Users repository implementation class.
/// </summary>
public sealed class UsersRepository : IUsersRepository
{
    /// <summary>
    /// Statistics for <paramref name="userID" />, <paramref name="from" /> and
    /// <paramref name="to" />-matched user statistics obtaining method.
    /// </summary>
    /// <param name="userID">User ID value.</param>
    /// <param name="from">Period from date/time value.</param>
    /// <param name="to">Period to date/time value.</param>
    /// <returns>
    /// Statistics-containing response for <paramref name="userID" />, <paramref name="from" /> and
    /// <paramref name="to" />-matched user statistics.
    /// </returns>
    public async Task<GetUserStatisticsData> GetUserStatistics(
        Guid userID,
        DateTimeOffset from,
        DateTimeOffset to
    ) {
        await using var kipServiceTestWorkContext = new KipServiceTestWorkContext();

        var userStatisticsData = await kipServiceTestWorkContext
            .UserSigns
            .Where(userSign =>
                userSign.UserID == userID &&
                userSign.SignDate >= from &&
                userSign.SignDate <= to
            )
            .ToListAsync();

        var converter = new Converters.Users.GetUserStatistics.Converter();

        return converter.Convert(userStatisticsData);
    }
}