using MediatR;


namespace Application.Commands.Products.CreateProduct
{
    public class CreateProductCommand:IRequest<int>
    {
        public string Sku { get; set; }  
        public string Name { get; set; } 
        public string? Description { get; set; }
        public decimal Price { get; set; } 
    }
}
