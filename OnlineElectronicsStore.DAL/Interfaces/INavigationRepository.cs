using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface INavigationRepository : IBaseRepository<Navigation>
{
    Task<List<string>> NavigationByRows(string name);
    Task<List<string>> NavigationRowsById(int id = 1);
}