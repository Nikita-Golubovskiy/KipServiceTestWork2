using System.Threading.Tasks;
using BusinessLogicLayer.KipServiceTestWork.Repository.Interfaces;
using PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.UpdateLog;
using PresentationLayer.KipServiceTestWork.Cqrs.Exceptions;
using PresentationLayer.KipServiceTestWork.Cqrs.Interfaces.Command.Canonical;

using Errors = PresentationLayer.KipServiceTestWork.Cqrs.Assets.Strings.Errors.Common;

namespace PresentationLayer.KipServiceTestWork.Cqrs.Commands;

/// <summary>
/// Log updating command class.
/// </summary>
public sealed class UpdateLog : IAsyncCommand<Request>
{
    /// <summary>
    /// Logs repository DI reference field.
    /// </summary>
    private readonly ILogsRepository logsRepository;

    /// <summary>
    /// Main constructor.
    /// </summary>
    /// <param name="logsRepository">Logs repository reference value, obtaining from DI.</param>
    public UpdateLog(ILogsRepository logsRepository)
    {
        this.logsRepository = logsRepository;
    }

    /// <summary>
    /// Command handling/execution method.
    /// </summary>
    /// <param name="request">Request data describing/containing object reference value.</param>
    /// <returns>Result data describing/containing object value.</returns>
    public async Task Execute(Request request)
    {
        if (request is null)
        {
            throw new CqrsException(Errors.REQUEST_ARGUMENT_IS_MISSING);
        }

        if (!await this.logsRepository.IsExist(request.ID))
        {
            throw new CqrsException(Errors.LOG_NOT_FOUND);
        }

        var log = await this.logsRepository.LoadLog(request.ID);

        log.AttachResponse(request.JsonResponse);

        await this.logsRepository.SaveLog(log);
    }
}