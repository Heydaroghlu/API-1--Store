using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.DTOs.ProductDTOs
{
    public class ProductPostDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public class ProductPostDTOValidator:AbstractValidator<ProductPostDTO>
        {
            public ProductPostDTOValidator()
            {
                RuleFor(x => x.Name).MaximumLength(150).MinimumLength(2).WithMessage("min 2").NotNull().WithMessage("Bosh ola bilmez");
                RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("min 0").WithMessage("0 dan awaqi ola bilmez!");
                RuleFor(x => x).Custom((x, context) =>
                  {
                      /*if (x.Name.Length > 150) { context.AddFailure("Adin uzunluqu 150  den coxdur"); }*/
                      if (x.Name.Length > 150) { context.AddFailure("Name", "Adin uzunluqu 150  den coxdur"); }
                  });
            }
        }
    }
}
