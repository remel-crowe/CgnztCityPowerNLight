using Microsoft.Xrm.Sdk;

namespace CognizantDataverse.Services
{
    /// <summary>
    /// Provides a generic interface for service classes to perform CRUD operations on entities.
    /// </summary>
    public interface IService<T> where T : Entity
    {
        Guid Create(T entity); 
        T GetById(Guid id);
        void Update(T entity);
        void Delete(Guid id);
        List<T> GetAll();
    }
}