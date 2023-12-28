using DataAccessLayer.KipServiceTestWork.Utilities.DataMigrator.Interfaces;

namespace DataAccessLayer.KipServiceTestWork.Utilities.DataMigrator.Migrators;

/// <summary>
/// Composite migrator class.
/// </summary>
internal class CompositeMigrator : BaseMigrator
{
    /// <summary>
    /// Atomic migrators collection reference field.
    /// </summary>
    private readonly IMigrator[] migrators;

    /// <summary>
    /// Run/apply migration method.
    /// </summary>
    protected sealed override void migrate()
    {
        foreach (var migration in this.migrators)
        {
            migration.Migrate();
        }
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="migrators">Atomic migrators collection reference value.</param>
    public CompositeMigrator(params IMigrator[] migrators)
    {
        this.migrators = migrators;
    }
}