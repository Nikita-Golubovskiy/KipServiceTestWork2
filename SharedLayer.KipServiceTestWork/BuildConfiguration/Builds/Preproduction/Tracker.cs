// Enable this variant of building configuration only for preproduction build configuration mode.

#if PREPRODUCTION

using SharedLayer.KipServiceTestWork.BuildConfiguration.Constants;

// ReSharper disable once CheckNamespace
namespace SharedLayer.KipServiceTestWork.BuildConfiguration;

/// <summary>
/// Build configuration tracking class.
/// </summary>
public static partial class Tracker
{
    /// <summary>
    /// Build configuration/informational section class.
    /// </summary>
    public static class Info
    {
        /// <summary>
        /// Build configuration type of <see cref="BuildConfigurations" /> value constant.
        /// </summary>
        public static readonly BuildConfigurations Type;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Info()
        {
            Tracker.Info.Type = BuildConfigurations.Preproduction;
        }
    }
}

#endif