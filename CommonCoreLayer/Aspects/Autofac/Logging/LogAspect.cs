using Castle.DynamicProxy;
using CommonCoreLayer.CrossCuttingConcerns.Logging;
using CommonCoreLayer.CrossCuttingConcerns.Logging.Log4Net;
using CommonCoreLayer.Utilities.Interceptors;
using CommonCoreLayer.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCoreLayer.Aspects.Autofac.Logging
{
    public class LogAspect:MethodInterception
    {
        private LoggerServiceBase loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            //loggerService tipi bir LoggerServiceBase değilse
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerService);
            }
            loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            loggerServiceBase.Info(GetLogDetail(invocation));
        }

        private LogDetail GetLogDetail(IInvocation invocation)
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

            var logDetail = new LogDetail()
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;

        }
    }
}
