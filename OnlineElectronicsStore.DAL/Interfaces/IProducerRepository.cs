using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IProducerRepository : IBaseRepository<Producer>
{
    Task<List<Producer>> NavigationByRows(string name);
    Task<List<Producer>> NavigationRowsById(int id);
}