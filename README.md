# Hangfire.Dashboard.Dark

[![Build Status](https://vip32.visualstudio.com/Hangfire.Dashboard.Dark/_apis/build/status/vip32.Hangfire.Dashboard.Dark?branchName=master)](https://vip32.visualstudio.com/Hangfire.Dashboard.Dark/_build/latest?definitionId=6&branchName=master)
[![NuGet](https://img.shields.io/nuget/v/Hangfire.Dashboard.Dark.svg)](https://www.nuget.org/packages/Hangfire.Dashboard.Dark/)

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

![dashboard](dashboard2.png)
