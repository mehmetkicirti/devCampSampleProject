using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    // Add çalıştırdığında invocation ilgili metod oluyor => Attribute ile OnBefore, OnException hangisini doldurursak ona göre attribute'u çalıştırıcak.
    public class MethodInterception:MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception ex) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        // Tüm metodlar önce buradan geçiçek Hangi Aspect hangi OnBefore hangisi doluysa o çalışıcak.
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed(); // method'u işle
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
