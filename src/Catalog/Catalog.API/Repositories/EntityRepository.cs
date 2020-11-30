using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;

namespace Catalog.API.Repositories
{
    public class EntityRepository : IEntityRepository<Product>
    {
        public Task Create(Entity product)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Entity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Entity> GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(Entity entidade)
        {
            throw new System.NotImplementedException();
        }
    }
}