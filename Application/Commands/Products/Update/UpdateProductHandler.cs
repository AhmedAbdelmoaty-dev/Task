using Application.Contracts.Repository;
using FluentValidation;
using MediatR;
using Application.Exceptions;
using Application.Extensions;

namespace Application.Commands.Products.Update
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand,Unit>
    {
        private readonly IProductsRepository _productRepository;
        private readonly IValidator<UpdateProductCommand> _validator;
        public UpdateProductHandler(IProductsRepository repo ,IValidator<UpdateProductCommand> validator)
        {
            _validator = validator;
            _productRepository = repo;
        }

        

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

           var validationResult=  await _validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
               throw new BadRequestException("Something went wrong",validationResult.ToDictionary());

           var existigProduct= await _productRepository.GetByIdAsync(request.Id);

            if (existigProduct == null)
               throw new NotFoundException($"proudct with id {request.Id} was not found");

           
            existigProduct.MapUpdates(request);

            _productRepository.Update(existigProduct);

          await  _productRepository.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
