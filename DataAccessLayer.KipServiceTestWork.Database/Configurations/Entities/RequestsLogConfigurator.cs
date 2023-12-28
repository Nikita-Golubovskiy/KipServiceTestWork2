using DataAccessLayer.KipServiceTestWork.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.KipServiceTestWork.Database.Configurations.Entities;

/// <summary>
/// EF Core model configuration providing class for <see cref="Log">Log</see> entity.
/// </summary>
internal sealed class RequestsLogConfigurator : IEntityTypeConfiguration<Log>
{
    /// <summary>
    /// <see cref="Log">Log</see> EF Core entity configuration applying method.
    /// </summary>
    /// <param name="builder">Corresponding EF Core entity configuration builder reference value.</param>
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("Logs");

        builder
            .HasKey(entity => entity.ID);

        builder
            .Property(entity => entity.ID)
            .HasColumnName("RequestsID")
            .HasColumnType("nvarchar")
            .HasMaxLength(36)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(entity => entity.RequestAt)
            .HasColumnType("datetimeoffset")
            .IsRequired();

        builder
            .Property(entity => entity.Request)
            .HasColumnType("nvarchar(max)")
            .IsRequired();

        builder
            .Property(entity => entity.Response)
            .HasColumnType("nvarchar(max)");
    }
}