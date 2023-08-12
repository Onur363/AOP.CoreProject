using Castle.DynamicProxy;
using CommonCoreLayer.Aspects.Autofac.Exception;
using CommonCoreLayer.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommonCoreLayer.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>().ToList();

            var methodAttribute = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>();

            classAttributes.AddRange(methodAttribute);
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            return classAttributes.OrderBy(p => p.Priority).ToArray();
        }
    }
}
