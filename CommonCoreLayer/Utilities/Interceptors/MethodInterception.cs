using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Interceptors
{
    public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { } //Metod çalışmadan önce sen çalış
        protected virtual void OnAfter(IInvocation invocation) { } //metod çalıştıktna sonra sen çalış
        protected virtual void OnException(IInvocation invocation,System.Exception e) { } //metod çalıştığında hata alırsa sen çalış
        protected virtual void OnSuccess(IInvocation invocation) { } //metod çalışma işlemi başarılı olduktan sonra sen çalış

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true; //ilk etapta işlem başarılı oldugunu varsayıyourz.

            OnBefore(invocation);
            try
            {
                //Invocation aslında bir bşr metoda attribute olarak verilen yapındaki metodun delege eder.
                invocation.Proceed(); //metodu çalıştır
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
