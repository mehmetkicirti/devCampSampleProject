using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    // Bu tür tool'lar uygulama boyunca bir instance olmalı
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object instance)
        {
            // Validator olarak kullanıcağımız nesnenin F12 ile içine gidip gerekli hangi fonksiyonu kullanıcaksak onun interface'ine ihtiyacımız var bu yüzden IValidator olarak parametre geçtik.
            var context = new ValidationContext<object>(instance);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
