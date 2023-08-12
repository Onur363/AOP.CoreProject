using CommonCoreLayer.Utilities.Interceptors;
using CommonCoreLayer.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CommonCoreLayer.CrossCuttingConcerns.Validation;
using Castle.DynamicProxy;

namespace CommonCoreLayer.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type validatorType;
        public ValidationAspect(Type validatorType)
        {
            //gönderilen bir validator Type IValidator tipin dedeğilse
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }

            this.validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //kullanılacak olan Validator a ulaştık (ProductValidator,CategoryValidator,UserValidator vs)
            var validator = (IValidator)Activator.CreateInstance(validatorType);
            var entityType = validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(p => p.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }

        }
    }
}
