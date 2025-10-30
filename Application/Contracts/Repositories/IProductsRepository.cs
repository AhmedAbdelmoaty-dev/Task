using Application.DTOS;
using System.Linq.Expressions;
using Domain.Entites;

namespace Application.Contracts.Repository
{
    public interface IProductsRepository
    {
        Task<ProductsResult> GetAsync(ProductParams productParams);

        Task<Product> GetByIdAsync(int id);
        
        void Create(Product product);
        
        void Update(Product product);
        
        void Delete (Product product);

        Task<bool> SaveChangesAsync();
    }
}
