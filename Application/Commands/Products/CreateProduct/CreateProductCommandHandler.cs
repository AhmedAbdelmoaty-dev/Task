using Application.Contracts.Repository;
using Application.Exceptions;
using Application.Extensions;
using FluentValidation;
using MediatR;


namespace Application.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IValidator<CreateProductCommand> _validator;
        public CreateProductCommandHandler(IProductsRepository productsRepository
            , IValidator<CreateProductCommand> validator)
        {
            _productsRepository=productsRepository;
            _validator=validator;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Something Went Wrong", validationResult.ToDictionary());
            }

            var product = request.ToEntity();

            _productsRepository.Create(product);

           var result= await _productsRepository.SaveChangesAsync();

            if (!result) throw new BadRequestException("Something went wrong while Creating product");

            return product.Id;
            
        }
    }
}
