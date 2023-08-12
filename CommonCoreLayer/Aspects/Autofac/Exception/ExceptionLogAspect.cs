using Castle.DynamicProxy;
using CommonCoreLayer.CrossCuttingConcerns.Logging;
using CommonCoreLayer.CrossCuttingConcerns.Logging.Log4Net;
using CommonCoreLayer.Utilities.Interceptors;
using CommonCoreLayer.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect:MethodInterception
    {
        private LoggerServiceBase loggerServiceBase;
        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerService);
            }

            loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter()
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetailWithException = new LogDetailWithException()
            {
                LogParameters = logParameters,
                MethodName = invocation.Method.Name,

            };

            return logDetailWithException;
        }
    }
}
