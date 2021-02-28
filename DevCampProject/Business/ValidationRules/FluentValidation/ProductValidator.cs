using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // Solid S => harfine aykırı oluyor tek satırda olmama sebebi yarın öbür gün o satırdaki kurala when kontrolü getirebiliriz.
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1);
            // Olmayan kuralı koymak istersek
            RuleFor(p => p.ProductName).Must(StartsWithA);
        }

        private bool StartsWithA(string arg) => arg.StartsWith("A");
    }
}
