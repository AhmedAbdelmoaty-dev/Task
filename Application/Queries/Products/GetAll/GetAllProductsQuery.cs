
using Application.DTOS;
using MediatR;

namespace Application.Queries.Products.GetAll
{
    public class GetAllProductsQuery : IRequest<PagedResult>
    {
        public string? Search { get; set; }

        public int PageSize { get; set; } = 10;

        public int PageIndex { get; set; } = 1;

        public bool IncludeDeleted { get; set; } = false;
    }

}
