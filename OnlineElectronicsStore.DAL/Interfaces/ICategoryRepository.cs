using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category> GetByNameAsync(string name);
}