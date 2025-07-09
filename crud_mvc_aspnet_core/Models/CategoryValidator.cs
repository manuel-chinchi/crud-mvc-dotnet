using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc_aspnet_core.Models
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            // Name property
            RuleFor(model => model.Name).Matches(@"^\w+( +\w+)*$").WithMessage("'Nombre' no puede ser solamente espacios en blanco, ni contener espacios al inicio o al final.");
            RuleFor(model => model.Name).NotEmpty().WithMessage("'Nombre' no puede ser vacío.");
            RuleFor(model => model.Name).MaximumLength(50);
            RuleFor(model => model.Name).MinimumLength(4).WithMessage("Por favor, indique un nombre más largo.");
        }
    }
}
