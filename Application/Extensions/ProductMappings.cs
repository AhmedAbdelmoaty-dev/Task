using Application.Commands.Products.CreateProduct;
using Application.Commands.Products.Update;
using Application.DTOS;
using Domain.Entites;


namespace Application.Extensions
{
    public static class ProductMappings
    {
        public static Product ToEntity(this CreateProductCommand createCommand)
        {
            return new Product
            {
                Name = createCommand.Name,
                Description = createCommand.Description,
                Price = createCommand.Price,
                Sku = createCommand.Sku,
                CreatedAtUtc = DateTime.UtcNow,
                IsDeleted=false
            };
        }

        public static void MapUpdates (this Product product, UpdateProductCommand command)
        {
            product.Price = command.Price;
            product.Description= command.Description;
            product.Sku= command.Sku;
            product.Name=command.Name;
            product.UpdatedAtUtc= DateTime.UtcNow;
        }

        public static ProductResponseDto ToProductResponseDto(this Product product)
        {
            return new ProductResponseDto
            {
                Id=product.Id,
                Price=product.Price,
                Description=product.Description,
                Name=product.Name,
                Sku=product.Sku,
                CreatedAtUtc=product.CreatedAtUtc,
                UpdatedAtUtc=product.UpdatedAtUtc
            };
        }


    }
}
