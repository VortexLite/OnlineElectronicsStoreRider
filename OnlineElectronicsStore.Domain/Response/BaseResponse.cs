using OnlineElectronicsStore.Domain.Enum;

namespace OnlineElectronicsStore.Domain.Response;

public class BaseResponse<T> : IBaseResponse<T>
{
    public string Desription { get; set; }
    
    public StatusCode StatusCode { get; set; }
    
    public T Data { get; set; }
}

public interface IBaseResponse<T>
{
    StatusCode StatusCode { get; set; }
    T Data { get; set; }
}