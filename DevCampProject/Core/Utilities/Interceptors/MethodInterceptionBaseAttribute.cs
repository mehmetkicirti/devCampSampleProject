using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    // Class, Methodlar uygulayabilirsin, birden fazla ve inherit edilen noktalardada kullanabilirsin
    //Hem veritabanına hemde dosyaya loglasın diyebiliriz.
    // Kodu çağırdığında belli bir kurala uyan attribute varmı git çalıştır => methoda girdiğinde işlemleri yapmadan ilk attributelar çalışıcak
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute:Attribute,IInterceptor
    {
        // Hangi attribute öncelikli çalışssın op. için
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}
