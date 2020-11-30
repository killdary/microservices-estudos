using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories.Interfaces
{
    public interface IEntityRepository<T> where T: Entity
    {         
         Task<IEnumerable<Entity>> GetAll();
         Task<Entity> GetById(string id);
         Task Create(Entity product);
         Task<bool> Update(Entity entidade);
         Task<bool> Delete(string id);
    }
}