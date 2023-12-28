using System;
using System.Collections.Generic;
using DataAccessLayer.KipServiceTestWork.Database.Contexts;
using DataAccessLayer.KipServiceTestWork.Database.Entities;
using EFCore.BulkExtensions;

using Messages = DataAccessLayer.KipServiceTestWork.Utilities.DataMigrator.Assets.Strings.Messages.Common;

namespace DataAccessLayer.KipServiceTestWork.Utilities.DataMigrator.Migrators.TestData;

/// <summary>
/// <see cref="Database.Entities.UserSign">UserSign</see> entities migrator.
/// </summary>
internal sealed class UserSignMigrator : BaseMigrator
{
    /// <summary>
    /// Random date time generated method.
    /// </summary>
    /// <param name="random">Random value.</param>
    /// <returns>Random date time value.</returns>
    private static DateTimeOffset generateRandomDateTime(Random random)
    {
        var minimalDateTime = new DateTime(1995, 1, 1);

        var range = (DateTime.Now - minimalDateTime).Days;

        var daysToAdd = random.Next(range);

        var result = minimalDateTime.AddDays(daysToAdd);

        result = result.AddHours(random.Next(0, 23));
        result = result.AddMinutes(random.Next(0, 59));
        result = result.AddSeconds(random.Next(0, 59));

        return result;
    }

    /// <summary>
    /// Before run/apply migration method.
    /// </summary>
    protected override void beforeMigrate()
    {
        Console.WriteLine(Messages.USER_SIGN_TEST_DATA_MIGRATION_START);
    }

    /// <summary>
    /// Run/apply migration method.
    /// </summary>
    protected override void migrate()
    {
        using var targetContext = new KipServiceTestWorkContext();

        var random = new Random();

        var entities = new List<UserSign>();

        var userIDs = new Guid[10];

        for (var index = 0; index < 10; ++index)
        {
            userIDs[index] = Guid.NewGuid();
        }

        for (var index = 0; index < 100; ++index)
        {
            var entityToAdd = new UserSign
            {
                UserID = userIDs[random.Next(0, 9)],
                SignDate = UserSignMigrator.generateRandomDateTime(random)
            };

            entities.Add(entityToAdd);
        }

        targetContext.BulkInsertOrUpdate(entities);
    }

    /// <summary>
    /// After run/apply migration method.
    /// </summary>
    protected override void afterMigrate()
    {
        Console.WriteLine(Messages.USER_SIGN_TEST_DATA_MIGRATION_FINISH);
    }
}