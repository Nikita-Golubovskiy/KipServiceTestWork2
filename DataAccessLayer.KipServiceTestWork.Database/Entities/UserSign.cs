using System;

namespace DataAccessLayer.KipServiceTestWork.Database.Entities;

/// <summary>
/// User sign POCO entity for EF Core ORM.
/// </summary>
public sealed class UserSign
{
    /// <summary>
    /// User ID property.
    /// </summary>
    public Guid? UserID { get; set; }

    /// <summary>
    /// User sign date property.
    /// </summary>
    public DateTimeOffset SignDate { get; set; }
}