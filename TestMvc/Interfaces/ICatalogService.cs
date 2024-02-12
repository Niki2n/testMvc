using TestMvc.Models;

namespace TestMvc.Interfaces
{
    public interface ICatalogService
    {
        Task<ServiceResponse<List<CatalogModel>>> GetAllAsync();
        Task<ServiceResponse<CatalogModel>> GetByAsync(int id);
        Task<ServiceResponse<List<CatalogModel>>> FindByAsync(string name);
        Task<ServiceResponse<CatalogModel>> CreateAsync(CatalogModel name);
        Task<ServiceResponse<CatalogModel>> EditAsync(CatalogModel name);
        Task<ServiceResponse> DeleteAsync(int id);
    }
}
