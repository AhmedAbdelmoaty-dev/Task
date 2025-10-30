

using Domain.Entites;

namespace Application.DTOS
{
    public class ProductsResult
    {
        public IReadOnlyList<Product> Products { get; set; }

        public int TotalCount { get; set; }
    }
}
