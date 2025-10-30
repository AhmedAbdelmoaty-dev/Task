
using Application.Contracts.Repository;
using Application.DTOS;
using Application.Exceptions;
using Application.Extensions;
using MediatR;

namespace Application.Queries.Products.GetById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponseDto>
    {
        private readonly IProductsRepository _productRepository;
        public GetProductByIdHandler(IProductsRepository repo)
        {
            _productRepository = repo;
        }
        public async Task<ProductResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
           var product= await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
                throw new NotFoundException($"Product with id {request.Id} was not found");

          var productResponseDto=  product.ToProductResponseDto();

            return productResponseDto;
        }
    }
}
