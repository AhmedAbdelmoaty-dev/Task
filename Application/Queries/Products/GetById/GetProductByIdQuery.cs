
using Application.DTOS;
using MediatR;

namespace Application.Queries.Products.GetById
{
    public class GetProductByIdQuery:IRequest<ProductResponseDto>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id= id;
        }
    }
}
