using Domain.Entites;
using FluentValidation;


namespace Application.Commands.Products.CreateProduct
{
    public class CreateProductValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(2, 100);

            RuleFor(x => x.Price).GreaterThan(0);

        }
    }
}
