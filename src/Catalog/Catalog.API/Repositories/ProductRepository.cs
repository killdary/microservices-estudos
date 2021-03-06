using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        
        private readonly ICatalogContext _context;            
    
        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq( p => p.Id, id);

            var deleteResult = await _context
                .Products
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged &&
                deleteResult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string id)
            => await _context
                .Products
                .AsQueryable()
                .Where(p => p.Id.Equals(id))
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetProductByCategoryName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch( p => p.Category.ToLower(), name.ToLower());

            return await _context
                .Products
                .Find(filter)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch( p => p.Name.ToLower(), name.ToLower());

            return await _context
                .Products
                .Find(filter)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
            => await _context
                .Products
                .Find(p => true)
                .ToListAsync();

        public async Task<bool> Update(Product product)
        {
            var updateResult = await _context
                .Products
                .ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);

                return updateResult.IsAcknowledged 
                    && updateResult.ModifiedCount > 0;
        }
    }
}