using Hangfire.Dashboard.Extensions;
using System;
using System.Reflection;

namespace Hangfire.Dashboard.Themes
{
    /// <summary>
    /// Enum containing the available theme options for hangfire
    /// </summary>
    public enum DashboardThemes
    {
        /// <summary>
        /// Dark theme available in the beta 4 of hangfire
        /// </summary>
        Dark,
        /// <summary>
        /// Custom transparent dark theme
        /// </summary>
        Glass
    }

    /// <summary>
    /// Provides extension methods to setup Hangfire.Dashboard
    /// </summary>
    public static class GlobalConfigurationExtensions
    {
        /// <summary>
        /// Configures Hangfire to a custom theme
        /// </summary>
        /// <param name="configuration">Global configuration</param>
        /// <param name="theme">Theme</param>
        public static IGlobalConfiguration UseCustomTheme(this IGlobalConfiguration configuration, DashboardThemes theme)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            // register dispatchers for CSS
            var assembly = typeof(GlobalConfigurationExtensions).GetTypeInfo().Assembly;

            switch (theme)
            {
                case DashboardThemes.Dark:
                    DashboardRoutes.Routes.Append("/css[0-9]+", new EmbeddedResourceDispatcher(assembly, "Hangfire.Dashboard.Themes.Resources.dark.css"));
                    break;
                case DashboardThemes.Glass:
                    DashboardRoutes.Routes.Append("/css[0-9]+", new EmbeddedResourceDispatcher(assembly, "Hangfire.Dashboard.Themes.Resources.dark.css")); //glass theme uses dark as base
                    DashboardRoutes.Routes.Append("/css[0-9]+", new EmbeddedResourceDispatcher(assembly, "Hangfire.Dashboard.Themes.Resources.glass.css"));
                    break;
            }

            return configuration;
        }
    }
}
