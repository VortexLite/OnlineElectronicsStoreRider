using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IProducerService
{
    Task<IBaseResponse<List<Producer>>> GetProducersAsync();
    Task<IBaseResponse<Producer>> GetProducerAsync(int id);
    Task<IBaseResponse<List<Producer>>> NavigationByRowsAsync(string name);
    Task<IBaseResponse<List<Producer>>> NavigationRowsByIdAsync(int id);
    Task<IBaseResponse<bool>> DeleteProducerAsync(int id);
}