using System;

namespace BusinessLogicLayer.KipServiceTestWork.Repository.ParameterObjects.IUsersRepository.GetUserStatistics;

/// <summary>
/// <see cref="Interfaces.IUsersRepository.GetUserStatistics">GetUserStatistics</see> response task describing parameter object DTO class.
/// </summary>
public record UserStatisticsData(
    Guid ID,
    int CountSignIn
) {
    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "ID: {0}, CountSignIn: {1}",
            this.ID,
            this.CountSignIn
        );
    }
}
