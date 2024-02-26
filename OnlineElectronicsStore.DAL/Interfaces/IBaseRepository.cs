using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IBaseRepository<T>
{
    bool Create(T entity);

    T Get(int id);

    Task<List<Category>> Select();

    bool Delete(T entity);
}