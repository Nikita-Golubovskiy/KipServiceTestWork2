using System.Diagnostics.CodeAnalysis;
using DataAccessLayer.KipServiceTestWork.Base.Interfaces.Connection;
using SharedLayer.KipServiceTestWork.BuildConfiguration;
using SharedLayer.KipServiceTestWork.BuildConfiguration.Constants;
using SharedLayer.KipServiceTestWork.Extensions;

namespace DataAccessLayer.KipServiceTestWork.Database.Connection;

/// <summary>
/// Implementation of <see cref="IConnectionStringBuilderFactory">IConnectionStringBuilderFactory</see> interface class.
/// </summary>
internal sealed class ConnectionStringBuilderFactory : IConnectionStringBuilderFactory
{
    /// <summary>
    /// An instance of <see cref="IConnectionStringBuilder">IConnectionStringBuilder</see> creating method.
    /// </summary>
    /// <param name="clientName">Name of some connection-dependent object.</param>
    /// <returns>An instance of <see cref="IConnectionStringBuilder">IConnectionStringBuilder</see>.</returns>
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public IConnectionStringBuilder CreateConnectionStringBuilder(string clientName)
    {
        return Tracker.Info.Type switch
        {
            BuildConfigurations.Debug => new Builders.FromConfigurationFile(
                clientName,
                BuildConfigurations.Debug.GetName(),
                "KipService",
                "4a9aEk40g"
            ),

            BuildConfigurations.Development => new Builders.FromConfigurationFile(
                clientName,
                BuildConfigurations.Development.GetName(),
                "KipService",
                "4a9aEk40g"
            ),

            BuildConfigurations.Test => new Builders.FromConfigurationFile(
                clientName,
                BuildConfigurations.Test.GetName(),
                "KipService",
                "4a9aEk40g"
            ),

            BuildConfigurations.Preproduction => new Builders.FromConfigurationFile(
                clientName,
                BuildConfigurations.Preproduction.GetName(),
                "KipService",
                "4a9aEk40g"
            ),

            BuildConfigurations.Production => new Builders.FromConfigurationFile(
                clientName,
                BuildConfigurations.Production.GetName(),
                "KipService",
                "4a9aEk40g"
            ),

            _ => new Builders.FromConfigurationFile(
                clientName,
                BuildConfigurations.Debug.GetName(),
                "KipService",
                "4a9aEk40g"
            )
        };
    }
}