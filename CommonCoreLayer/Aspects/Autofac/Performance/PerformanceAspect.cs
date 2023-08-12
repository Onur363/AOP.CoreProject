using CommonCoreLayer.Utilities.Interceptors;
using CommonCoreLayer.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace CommonCoreLayer.Aspects.Autofac.Performance
{
    public class PerformanceAspect:MethodInterception
    {
        private int interval;
        private Stopwatch stopwatch;

        public PerformanceAspect(int interval)
        {
            this.interval = interval;
            stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (stopwatch.Elapsed.TotalSeconds > interval)
            {
                Debug.WriteLine($"Perofmance {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} Elapsed Time--> {stopwatch.Elapsed.TotalSeconds}");
            }
            stopwatch.Restart();
        }
    }
}
