using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Response;

namespace OnlineElectronicsStore.Service.Interfaces;

public interface IProducerService
{
    Task<IBaseResponse<List<Producer>>> GetProducers();
    Task<IBaseResponse<Producer>> GetProducer(int id);
    Task<IBaseResponse<List<Producer>>> NavigationByRows(string name);
    Task<IBaseResponse<List<Producer>>> NavigationRowsById(int id);
    Task<IBaseResponse<bool>> DeleteProducer(int id);
}