# Hangfire.Dashboard.Dark

[![NuGet](https://img.shields.io/nuget/v/rodriGS750.Hangfire.Dashboard.Themes.Dark)](https://www.nuget.org/packages/rodriGS750.Hangfire.Dashboard.Themes.Dark/)

Enables the usage of predefined custom css for the dashboard.

## Themes

### Dark (by [@odinserj](https://github.com/HangfireIO/Hangfire/blob/master/src/Hangfire.Core/Dashboard/Content/css/hangfire-dark.css))
![dashboard1](https://user-images.githubusercontent.com/57366583/222802062-5d42dcb3-ea57-4e1f-afa4-661e7d96b6c6.png)
![dashboard2](https://user-images.githubusercontent.com/57366583/222802085-08a14f96-ef34-4ffc-9ccf-55e2d44d7f3c.png)


### Glass
![image](https://user-images.githubusercontent.com/57366583/222836080-a4efce20-1dcc-423f-9b01-80336bacc3c5.png)
![image](https://user-images.githubusercontent.com/57366583/222836569-c014f31a-fe1b-47f5-afdd-f0561f8b9d6c.png)



## Setup

In .NET Core's Startup.cs:
```c#
using Hangfire.Dashboard.Themes;

public void ConfigureServices(IServiceCollection services)
{
    services.AddHangfire(config =>
    {
        ...
        config.UseCustomTheme(DashboardThemes.Dark); //Select custom theme
    });
}
```

Otherwise,
```c#
GlobalConfiguration.Configuration
    ...
    ..UseCustomTheme(DashboardThemes.Dark)
```

###After changing themes remember to clear cache (CTRL+F5) otherwise the new css won't load.

