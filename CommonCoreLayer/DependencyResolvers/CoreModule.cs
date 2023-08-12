using CommonCoreLayer.CrossCuttingConcerns.Caching;
using CommonCoreLayer.CrossCuttingConcerns.Caching.Microsoft;
using CommonCoreLayer.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CommonCoreLayer.DependencyResolvers
{
    public class CoreModule : ICommonCoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddSingleton<ICacheManager, MemoryCacheManager>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddStackExchangeRedisCache(action =>
            {
                action.Configuration = "localhost:6379";
            });

            services.AddSingleton<Stopwatch>();
        }
    }
}
