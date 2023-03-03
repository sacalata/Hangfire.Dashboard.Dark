# Hangfire.Dashboard.Dark

[![NuGet](https://img.shields.io/nuget/v/Hangfire.Dashboard.Dark.svg)](https://www.nuget.org/packages/rodriGS750.Hangfire.Dashboard.Themes.Dark/)

Uses the hangfire-dark.css available on beta 4. 

## Features

-Todo add screenshot

## Setup

In .NET Core's Startup.cs:
```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddHangfire(config =>
    {
        ...
        config.UseDarkDashboard();
    });
}
```

Otherwise,
```c#
GlobalConfiguration.Configuration
    ...
    .UseDarkDashboard();
```

