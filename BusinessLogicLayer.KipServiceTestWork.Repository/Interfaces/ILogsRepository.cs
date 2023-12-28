using System;
using System.Threading.Tasks;

using LogModel = BusinessLogicLayer.KipServiceTestWork.Model.Log;

// ReSharper disable UnusedMember.Global

namespace BusinessLogicLayer.KipServiceTestWork.Repository.Interfaces;

/// <summary>
/// Logs repository model interface.
/// </summary>
public interface ILogsRepository
{
    /// <summary>
    /// Log existence checking by <paramref name="id" /> method.
    /// </summary>
    /// <param name="id">Log ID value.</param>
    /// <returns>True, if log with specified <paramref name="id" /> exists. Otherwise, returns false.</returns>
    Task<bool> IsExist(Guid id);

    /// <summary>
    /// Log DDD model with child models by log <paramref name="id" /> loading method.
    /// </summary>
    /// <param name="id">Log ID, which one must be loaded.</param>
    /// <returns>Loaded log DDD model.</returns>
    Task<LogModel> LoadLog(Guid id);

    /// <summary>
    /// Log DDD model from <paramref name="model" /> with child models saving method.
    /// </summary>
    /// <param name="model">Log DDD model, which one must be saved.</param>
    /// <returns>Result descriptor.</returns>
    Task SaveLog(LogModel model);
}