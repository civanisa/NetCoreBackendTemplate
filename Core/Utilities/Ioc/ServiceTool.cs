﻿#region Imports
using Microsoft.Extensions.DependencyInjection;
using System;

#endregion

namespace Core.Utilities.Ioc
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
