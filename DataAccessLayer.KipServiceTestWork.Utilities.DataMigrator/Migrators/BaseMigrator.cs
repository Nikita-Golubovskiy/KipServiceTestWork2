using DataAccessLayer.KipServiceTestWork.Utilities.DataMigrator.Interfaces;

namespace DataAccessLayer.KipServiceTestWork.Utilities.DataMigrator.Migrators;

/// <summary>
/// Base <see cref="IMigrator">IMigrator</see> implementation class.
/// </summary>
internal abstract class BaseMigrator : IMigrator
{
    /// <summary>
    /// Before run/apply migration method.
    /// </summary>
    protected virtual void beforeMigrate()
    {
    }

    /// <summary>
    /// Run/apply migration method.
    /// </summary>
    protected abstract void migrate();

    /// <summary>
    /// After run/apply migration method.
    /// </summary>
    protected virtual void afterMigrate()
    {
    }

    /// <summary>
    /// Run/apply migration method.
    /// </summary>
    public void Migrate()
    {
        this.beforeMigrate();
        this.migrate();
        this.afterMigrate();
    }
}