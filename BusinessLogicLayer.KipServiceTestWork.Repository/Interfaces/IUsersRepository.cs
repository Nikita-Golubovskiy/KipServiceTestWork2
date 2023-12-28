using System;
using System.Threading.Tasks;

using GetUserStatisticsData = BusinessLogicLayer.KipServiceTestWork.Repository.ParameterObjects.IUsersRepository.GetUserStatistics.UserStatisticsData;

// ReSharper disable UnusedMember.Global

namespace BusinessLogicLayer.KipServiceTestWork.Repository.Interfaces;

/// <summary>
/// Users repository model interface.
/// </summary>
public interface IUsersRepository
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
    Task<GetUserStatisticsData> GetUserStatistics(Guid userID, DateTimeOffset from, DateTimeOffset to);
}