using System.Threading.Tasks;
using BusinessLogicLayer.KipServiceTestWork.Repository.Interfaces;
using PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.CreateLog;
using PresentationLayer.KipServiceTestWork.Cqrs.Exceptions;
using PresentationLayer.KipServiceTestWork.Cqrs.Interfaces.Command.NonCanonical;

using LogModel = BusinessLogicLayer.KipServiceTestWork.Model.Log;

using Errors = PresentationLayer.KipServiceTestWork.Cqrs.Assets.Strings.Errors.Common;

namespace PresentationLayer.KipServiceTestWork.Cqrs.Commands;

/// <summary>
/// New log creating command class.
/// </summary>
public sealed class CreateLog : IAsyncCommand<Request, Response>
{
    /// <summary>
    /// Logs repository DI reference field.
    /// </summary>
    private readonly ILogsRepository logsRepository;

    /// <summary>
    /// Main constructor.
    /// </summary>
    /// <param name="logsRepository">Logs repository reference value, obtaining from DI.</param>
    public CreateLog(ILogsRepository logsRepository)
    {
        this.logsRepository = logsRepository;
    }

    /// <summary>
    /// Command handling/execution method.
    /// </summary>
    /// <param name="request">Request data describing/containing object reference value.</param>
    /// <returns>Result data describing/containing object value.</returns>
    public async Task<Response> Execute(Request request)
    {
        if (request is null)
        {
            throw new CqrsException(Errors.REQUEST_ARGUMENT_IS_MISSING);
        }

        var log = new LogModel(
            request.JsonRequest
        );

        await this.logsRepository.SaveLog(log);

        var result = new Response(log.ID.ToString());

        return result;
    }
}