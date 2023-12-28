using System.Reflection;
using DataAccessLayer.KipServiceTestWork.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.KipServiceTestWork.Database.Contexts;

/// <summary>
/// KipServiceTestWork context class.
/// </summary>
public class KipServiceTestWorkContext : BaseDbContext<KipServiceTestWorkContext>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public KipServiceTestWorkContext()
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="options">Database context configuration options reference value.</param>
    public KipServiceTestWorkContext(DbContextOptions<KipServiceTestWorkContext> options) : base(options)
    {
    }

    /// <summary>
    /// User signs set property.
    /// </summary>
    public virtual DbSet<UserSign> UserSigns { get; set; }

    /// <summary>
    /// Logs set property.
    /// </summary>
    public virtual DbSet<Log> Logs { get; set; }

    /// <summary>
    /// Override this method to further configure the model that was discovered by convention
    /// from the entity types exposed in <see cref="DbSet{TEntity}">DbSet</see> properties
    /// on your derived context. The resulting model may be cached and re-used for subsequent
    /// instances of your derived context.
    /// </summary>
    /// <param name="modelBuilder">
    /// The builder being used to construct the model for this context. Databases (and
    /// other extensions) typically define extension methods on this object that allow
    /// you to configure aspects of the model that are specific to a given database.
    /// </param>
    /// <remarks>
    /// If a model is explicitly set on the options for this context, then this method will not be run.
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}