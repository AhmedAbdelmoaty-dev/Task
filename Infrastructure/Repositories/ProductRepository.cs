using Application.Contracts.Repository;
using Application.DTOS;
using Domain.Entites;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductsRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// returns an object which contain list of products and the total resulted count of the query
        /// </summary>
        /// <param name="productParams"></param>
        /// <returns></returns>
        public async Task<ProductsResult> GetAsync(ProductParams productParams)
        {
            var productQuery=_context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(productParams.Search))
            {
                productQuery= productQuery.Where(x=>x.Name.Contains(productParams.Search));
            }

            if (productParams.IncludeDeleted)
            {
                productQuery= productQuery.IgnoreQueryFilters();
            }

            var totalCount = await productQuery.CountAsync();

            productQuery = productQuery.Skip((productParams.PageIndex-1)*productParams.PageSize).Take(productParams.PageSize);

            var products = await productQuery.ToListAsync();
           
            return new ProductsResult { Products = products, TotalCount = totalCount };
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
          return await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
        }

        public void Delete(Product product)
        {
            product.IsDeleted= true;
        }


        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
        public async Task<bool> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync()>0;
        }


    }
}
