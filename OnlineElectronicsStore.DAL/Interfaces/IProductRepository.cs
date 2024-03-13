using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product> GetByName(string name);
}