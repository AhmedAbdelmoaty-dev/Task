
using Application.Contracts.Repository;
using Application.DTOS;
using Application.Extensions;
using MediatR;
using System.Runtime.CompilerServices;

namespace Application.Queries.Products.GetAll
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, PagedResult>
    {
        private readonly IProductsRepository _productsRepository;
        public GetAllProductsHandler(IProductsRepository repo)
        {
            _productsRepository = repo;
        }
        public async Task<PagedResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var parameters = new ProductParams
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Search = request.Search,
                IncludeDeleted= request.IncludeDeleted,
            };

          var resultProducts=  await _productsRepository.GetAsync(parameters);
          
          var ProductResponseDtos= new List<ProductResponseDto>();
          
            
            foreach (var product in resultProducts.Products)
            {
                ProductResponseDtos.Add(product.ToProductResponseDto());
            }

            return new PagedResult
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                productsDtos = ProductResponseDtos,
                TotalCount=resultProducts.TotalCount    
            };
        }


    }
}
