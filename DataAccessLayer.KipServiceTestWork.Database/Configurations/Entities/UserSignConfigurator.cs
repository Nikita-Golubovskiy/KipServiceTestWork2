using DataAccessLayer.KipServiceTestWork.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.KipServiceTestWork.Database.Configurations.Entities;

/// <summary>
/// EF Core model configuration providing class for <see cref="UserSign">UserSign</see> entity.
/// </summary>
internal sealed class UserSignConfigurator : IEntityTypeConfiguration<UserSign>
{
    /// <summary>
    /// <see cref="UserSign">UserSign</see> EF Core entity configuration applying method.
    /// </summary>
    /// <param name="builder">Corresponding EF Core entity configuration builder reference value.</param>
    public void Configure(EntityTypeBuilder<UserSign> builder)
    {
        builder.ToTable("UserSigns");

        builder
            .HasKey(entity => new {entity.UserID, entity.SignDate});

        builder
            .Property(entity => entity.UserID)
            .HasColumnName("UserID")
            .HasColumnType("nvarchar")
            .HasMaxLength(36)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .Property(entity => entity.SignDate)
            .HasColumnType("datetimeoffset")
            .IsRequired();
    }
}