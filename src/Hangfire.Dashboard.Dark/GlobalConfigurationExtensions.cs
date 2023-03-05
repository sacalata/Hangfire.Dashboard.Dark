using Hangfire.Dashboard.Extensions;
using System;
using System.IO;
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

        /// <summary>
        /// Adds a custom CSS file to the dashboard layout. The CSS file must be an embedded resource in the specified assembly.
        /// </summary>
        /// <param name="configuration">The global configuration.</param>
        /// <param name="assembly">The assembly that contains the embedded resource.</param>
        /// <param name="resourceName">The name of the embedded resource.</param>
        /// <exception cref="ArgumentNullException">Thrown when either the <paramref name="assembly"/> or <paramref name="resourceName"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the specified resource is not found in the assembly or is not a CSS file.</exception>
        public static IGlobalConfiguration AddCustomCss(this IGlobalConfiguration configuration, Assembly assembly, string resourceName)
        {
            if (string.IsNullOrEmpty(resourceName))
                throw new ArgumentNullException(nameof(resourceName));
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            var resourceInfo = assembly.GetManifestResourceInfo(resourceName);
            var extension = Path.GetExtension(resourceName);

            if (resourceInfo == null)
            {
                throw new ArgumentException($"Resource '{resourceName}' not found in assembly.");
            }

            if (!string.Equals(extension, ".css", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"Resource '{resourceName}' is not a CSS file.");
            }

            DashboardRoutes.Routes.Append("/css[0-9]+", new EmbeddedResourceDispatcher(assembly, resourceName));
            return configuration;
        }
    }



}
