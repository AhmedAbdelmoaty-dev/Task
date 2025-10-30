using FluentValidation;

namespace Application.Commands.Products.Update
{
    public class UpdateProductValidator:AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(2, 100);

            RuleFor(x => x.Price).GreaterThan(0);

            RuleFor(x => x.Sku).NotEmpty();
        }
    }
}
