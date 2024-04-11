using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IProducerRepository : IBaseRepository<Producer>
{
    Task<List<Producer>> NavigationByRowsAsync(string name);
    Task<List<Producer>> NavigationRowsByIdAsync(int id);
}