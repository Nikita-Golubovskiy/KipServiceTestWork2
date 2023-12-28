using DataAccessLayer.KipServiceTestWork.Utilities.DataMigrator.Migrators;

using TestData = DataAccessLayer.KipServiceTestWork.Utilities.DataMigrator.Migrators.TestData;

namespace DataAccessLayer.KipServiceTestWork.Utilities.DataMigrator;

/// <summary>
/// Application entry point containing class.
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Database data migration method.
    /// </summary>
    private static void migrateData()
    {
        var migrator = new CompositeMigrator(
            new TestData.UserSignMigrator()
        );

        migrator.Migrate();
    }

    /// <summary>
    /// Run migration method.
    /// </summary>
    private static void runMigration()
    {
        Program.migrateData();
    }

    /// <summary>
    /// Entry point method.
    /// </summary>
    /// <param name="args">Command line arguments values.</param>
    public static void Main(string[] args)
    {
        Program.runMigration();
    }
}