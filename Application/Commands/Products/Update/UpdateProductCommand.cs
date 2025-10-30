using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Products.Update
{
    public class UpdateProductCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Sku { get; set; }  
        public string Name { get; set; } 
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
