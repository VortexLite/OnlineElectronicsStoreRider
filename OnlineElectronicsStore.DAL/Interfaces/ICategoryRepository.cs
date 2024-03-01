using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<Category> GetByName(string name);
}