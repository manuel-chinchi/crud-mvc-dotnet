using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_mvc.Models
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            // Name property 
            //https://stackoverflow.com/questions/15472764/regular-expression-to-allow-spaces-between-words (regex validation)
            RuleFor(model => model.Name).Matches(@"^\w+( +\w+)*$").WithMessage("'Nombre' no puede ser solamente espacios en blanco, ni contener espacios al inicio o al final.");
            RuleFor(model => model.Name).NotEmpty().WithMessage("'Nombre' no puede ser vacío.");
            RuleFor(model => model.Name).MaximumLength(50);

            // Description property
            RuleFor(model => model.Description).NotEmpty().WithMessage("'Descripción' no puede ser vacío.");
            RuleFor(model => model.Description).MaximumLength(50).WithMessage("'Descripción' no puede contener más de 50 carácteres.");

            // Quantity property
            RuleFor(model => model.Quantity).NotNull().WithMessage("'Cantidad' es requerido.");
            RuleFor(model => model.Quantity).GreaterThanOrEqualTo(1).WithMessage("'Cantidad' debe ser mayor o igual a 1.");
        }
    }
}
