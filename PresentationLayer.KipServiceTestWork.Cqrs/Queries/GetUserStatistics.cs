using System.Threading.Tasks;
using BusinessLogicLayer.KipServiceTestWork.Repository.Interfaces;
using PresentationLayer.KipServiceTestWork.Cqrs.DataTransferObjects.GetUserStatistics;
using PresentationLayer.KipServiceTestWork.Cqrs.Exceptions;
using PresentationLayer.KipServiceTestWork.Cqrs.Interfaces.Query.Parametric;

using Errors = PresentationLayer.KipServiceTestWork.Cqrs.Assets.Strings.Errors.Common;

namespace PresentationLayer.KipServiceTestWork.Cqrs.Queries;

/// <summary>
/// User statistic providing query class.
/// </summary>
public sealed class GetUserStatistics : IAsyncQuery<Request, Response>
{
    /// <summary>
    /// Users repository DI reference field.
    /// </summary>
    private readonly IUsersRepository usersRepository;

    /// <summary>
    /// Main constructor.
    /// </summary>
    /// <param name="usersRepository">Users repository reference value, obtaining from DI.</param>
    public GetUserStatistics(IUsersRepository usersRepository)
    {
        this.usersRepository = usersRepository;
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

        var userStatistics = await this.usersRepository.GetUserStatistics(
            request.UserID,
            request.From,
            request.To
        );

        var converter = new Converters.GetUserStatistics.Converter();

        return converter.Convert(userStatistics);
    }
}