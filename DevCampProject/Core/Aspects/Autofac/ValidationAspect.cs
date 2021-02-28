using System;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using FluentValidation;
using System.Linq;
using Core.CrossCuttingConcerns.Validation;

namespace Core.Aspects.Autofac
{
    public class ValidationAspect: MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //gönderdiğim type validator => eğer bir IValidator interface'ınden türeyen bir validatorSınıfı değil ise exception fırlat 
            //defensive coding
            // o gönderdiğin tip IValidator'mu
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                //AspectMessages.WrongValidationType
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //çalışma anında 
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // attribute olarak gönderdiğim validator'ın instance'ını yarattık reflection sayesinde
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // AbstractValidator<Product> => buradaki Product'ı alıcak mesela çalışma tipini bul demek istiyor
            var entities = invocation.Arguments.Where(i => i.GetType() == entityType); // ilgili methodun parametrelerine bak validator'ın tipine eşit olanlarını bul diyor
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator,entity); // burada birden fazla attribute göndermiş olabiliriz her biri için validate edicek.
            }
        }
    }
}
