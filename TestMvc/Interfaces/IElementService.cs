using TestMvc.Models;

namespace TestMvc.Interfaces
{
    public interface IElementService
    {
        Task<ServiceResponse<ElementModel>> get(int page, int pageSize);
    }
}
