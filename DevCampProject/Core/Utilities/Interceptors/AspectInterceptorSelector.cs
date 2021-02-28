using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;
using System.Linq;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //classın attribute'unu oku
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            // methodun attributelarını oku
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            // Otomatik olarak tüm sisteme loglama altyapısını ekler.
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)))
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
