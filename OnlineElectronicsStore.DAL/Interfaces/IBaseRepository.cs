using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IBaseRepository<T>
{
    Task<bool> Create(T entity);

    Task<Category> Get(int id);

    Task<List<Category>> Select();

    Task<bool> Delete(T entity);

    Task<T> Update(T entity);
}