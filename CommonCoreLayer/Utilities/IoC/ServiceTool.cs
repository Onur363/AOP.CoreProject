using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; set; }

        //ISericieCollection veProvide .Net library içinde resolverını yapıyor
        public static IServiceCollection Create(IServiceCollection service)
        {
            ServiceProvider = service.BuildServiceProvider();
            return service;
        }
    }
}
