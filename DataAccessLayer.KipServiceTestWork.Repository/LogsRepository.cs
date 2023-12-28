using System;
using System.Threading.Tasks;
using BusinessLogicLayer.KipServiceTestWork.Repository.Interfaces;
using DataAccessLayer.KipServiceTestWork.Database.Contexts;
using Microsoft.EntityFrameworkCore;

using LogEntity = DataAccessLayer.KipServiceTestWork.Database.Entities.Log;
using LogModel = BusinessLogicLayer.KipServiceTestWork.Model.Log;

namespace DataAccessLayer.KipServiceTestWork.Repository;

/// <summary>
/// Logs repository implementation class.
/// </summary>
public sealed class LogsRepository : ILogsRepository
{
    /// <summary>
    /// Log existence checking by <paramref name="id" /> method.
    /// </summary>
    /// <param name="id">Log ID value.</param>
    /// <returns>True, if log with specified <paramref name="id" /> exists. Otherwise, returns false.</returns>
    public async Task<bool> IsExist(Guid id)
    {
        await using var kipServiceTestWorkContext = new KipServiceTestWorkContext();

        var result = await kipServiceTestWorkContext
            .Logs
            .AsNoTracking()
            .AnyAsync(log => log.ID == id);

        return result;
    }

    /// <summary>
    /// Log DDD model with child models by log <paramref name="id" /> loading method.
    /// </summary>
    /// <param name="id">Log ID, which one must be loaded.</param>
    /// <returns>Loaded log DDD model.</returns>
    public async Task<LogModel> LoadLog(Guid id)
    {
        await using var kipServiceTestWorkContext = new KipServiceTestWorkContext();

        var resultTask = await kipServiceTestWorkContext
            .Logs
            .AsNoTracking()
            .SingleAsync(task => task.ID == id);

        var converter = new Converters.Logs.LoadLog.Converter();

        return converter.Convert(resultTask);
    }

    /// <summary>
    /// Log DDD model from <paramref name="model" /> with child models saving method.
    /// </summary>
    /// <param name="model">Log DDD model, which one must be saved.</param>
    /// <returns>Result descriptor.</returns>
    public async Task SaveLog(LogModel model)
    {
        await using var kipServiceTestWorkContext = new KipServiceTestWorkContext();

        var isExists = await this.IsExist(model.ID);

        var taskEntity = await kipServiceTestWorkContext
            .Logs
            .SingleOrDefaultAsync(task => task.ID == model.ID);

        taskEntity ??= new LogEntity
        {
            ID = model.ID
        };

        taskEntity.RequestAt = model.RequestAt;
        taskEntity.Request = model.Request;
        taskEntity.Response = model.Response;

        if (isExists)
        {
            kipServiceTestWorkContext.Update(taskEntity);
        }
        else
        {
            kipServiceTestWorkContext.Add(taskEntity);
        }

        await kipServiceTestWorkContext
            .SaveChangesAsync()
            .ConfigureAwait(false);
    }
}