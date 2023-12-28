using System.Threading.Tasks;
using BusinessLogicLayer.KipServiceTestWork.Repository.Interfaces;
using PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetLogInformation;
using PresentationLayer.KipServiceTestWork.Cqrs.Exceptions;
using PresentationLayer.KipServiceTestWork.Cqrs.Interfaces.Query.Parametric;

using Errors = PresentationLayer.KipServiceTestWork.Cqrs.Assets.Strings.Errors.Common;

namespace PresentationLayer.KipServiceTestWork.Cqrs.Queries;

/// <summary>
/// Log information providing query class.
/// </summary>
public sealed class GetLogInformation : IAsyncQuery<Request, Response>
{
    /// <summary>
    /// Logs repository DI reference field.
    /// </summary>
    private readonly ILogsRepository logsRepository;

    /// <summary>
    /// Main constructor.
    /// </summary>
    /// <param name="logsRepository">Logs repository reference value, obtaining from DI.</param>
    public GetLogInformation(ILogsRepository logsRepository)
    {
        this.logsRepository = logsRepository;
    }

    /// <summary>
    /// Query handling/execution method.
    /// </summary>
    /// <param name="request">Request data describing/containing object reference value.</param>
    /// <returns>Result data describing/containing object value.</returns>
    public async Task<Response> Execute(Request request)
    {
        if (request is null)
        {
            throw new CqrsException(Errors.REQUEST_ARGUMENT_IS_MISSING);
        }

        if (!await this.logsRepository.IsExist(request.LogID))
        {
            throw new CqrsException(Errors.LOG_NOT_FOUND);
        }

        var log = await this.logsRepository.LoadLog(request.LogID);

        var completionAt = log.RequestAt.AddSeconds(request.DelaySecond);

        var converter = new Converters.GetLogInformation.Converter(completionAt);

        return converter.Convert(log);
    }
}