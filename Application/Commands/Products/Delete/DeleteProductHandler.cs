using Application.Contracts.Repository;
using MediatR;
using Domain.Entites;

using Application.Exceptions;

namespace Application.Commands.Products.Delete
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductsRepository _productRepository;

        public DeleteProductHandler(IProductsRepository repo)
        {
            _productRepository = repo;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

          var existingProduct= await  _productRepository.GetByIdAsync(request.Id);

            if (existingProduct == null)
                throw new NotFoundException($"Product with id {request.Id} was not found");
           
            _productRepository.Delete(existingProduct);

            await _productRepository.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
