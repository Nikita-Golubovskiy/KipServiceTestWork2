namespace DataAccessLayer.KipServiceTestWork.Utilities.DataMigrator.Interfaces;

/// <summary>
/// Common migration interface.
/// </summary>
internal interface IMigrator
{
    /// <summary>
    /// Run/apply migration method.
    /// </summary>
    void Migrate();
}