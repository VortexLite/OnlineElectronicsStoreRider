using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Category GetByName(string name);
    
}