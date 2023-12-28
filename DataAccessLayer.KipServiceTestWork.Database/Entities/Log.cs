using System;

namespace DataAccessLayer.KipServiceTestWork.Database.Entities;

/// <summary>
/// Log POCO entity for EF Core ORM.
/// </summary>
public sealed class Log
{
    /// <summary>
    /// Request ID property.
    /// </summary>
    public Guid? ID { get; set; }

    /// <summary>
    /// Request at date/time property.
    /// </summary>
    public DateTimeOffset RequestAt { get; set; }

    /// <summary>
    /// Request property.
    /// </summary>
    public string Request { get; set; }

    /// <summary>
    /// Response property.
    /// </summary>
    public string Response { get; set; }
}