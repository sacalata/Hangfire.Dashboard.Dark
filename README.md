# Hangfire.Dashboard.Dark

[![NuGet](https://img.shields.io/nuget/v/rodriGS750.Hangfire.Dashboard.Themes.Dark)](https://www.nuget.org/packages/rodriGS750.Hangfire.Dashboard.Themes.Dark/)

Uses the hangfire-dark.css available on beta 4. 

## Features
![dashboard1](https://user-images.githubusercontent.com/57366583/222802062-5d42dcb3-ea57-4e1f-afa4-661e7d96b6c6.png)


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

![dashboard2](https://user-images.githubusercontent.com/57366583/222802085-08a14f96-ef34-4ffc-9ccf-55e2d44d7f3c.png)

