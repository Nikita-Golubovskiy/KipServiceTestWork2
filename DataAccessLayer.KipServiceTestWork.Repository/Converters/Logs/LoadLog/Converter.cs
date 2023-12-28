using SharedLayer.KipServiceTestWork.Interfaces;

using EntityObject = DataAccessLayer.KipServiceTestWork.Database.Entities.Log;
using ModelObject = BusinessLogicLayer.KipServiceTestWork.Model.Log;

namespace DataAccessLayer.KipServiceTestWork.Repository.Converters.Logs.LoadLog;

/// <summary>
/// <see cref="EntityObject">EntityObject</see> repository parameter objects to <see cref="ModelObject">ModelObject</see> object converter.
/// </summary>
internal sealed class Converter : IDirectConverter<EntityObject, ModelObject>
{
    /// <summary>
    /// Value conversion method.
    /// </summary>
    /// <param name="source">Source value to convert.</param>
    /// <returns>Result/converted value.</returns>
    public ModelObject Convert(EntityObject source)
    {
        if (source is null)
        {
            return null;
        }
        var result = new ModelObject(
            // ReSharper disable once PossibleInvalidOperationException
            source.ID.Value,
            source.RequestAt,
            source.Request,
            source.Response
        );

        return result;
    }
}