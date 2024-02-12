using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Xml.Linq;
using TestMvc.Interfaces;
using TestMvc.Models;
using TestMvc.Options;

namespace TestMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiOptions _options;

        public CatalogService(IHttpClientFactory httpClientFactory, IOptions<ApiOptions> options)
        {
            _httpClient = httpClientFactory.CreateClient(ApiOptions.ClientName);
            _options = options.Value;
        }

        public async Task<ServiceResponse<List<CatalogModel>>> GetAllAsync()
        {
            var answer = await _httpClient.GetAsync(_options.GetCatalogsEp);
            if(answer.IsSuccessStatusCode)
            {
                var catalogs = JsonSerializer.Deserialize<List<CatalogModel>>(
                    await answer.Content.ReadAsStringAsync(),
                    SerializeOptions.CamelCase
                    );
                if(catalogs == null ||  catalogs.Count == 0)
                {
                    return new ServiceResponse<List<CatalogModel>>("Empty list");
                }
                return new ServiceResponse<List<CatalogModel>>(catalogs);
            }
            return  new ServiceResponse<List<CatalogModel>>(answer.StatusCode.ToString()); ;
        }

        public async Task<ServiceResponse<CatalogModel>> GetByAsync(int id)
        {
            var answer = await _httpClient.GetAsync($"{_options.GetCatalogByIdEp}{id}");
            if(answer.IsSuccessStatusCode)
            {
                var catalog = JsonSerializer.Deserialize<CatalogModel>(
                   await answer.Content.ReadAsStringAsync(),
                   SerializeOptions.CamelCase
                   );
                if(catalog == null)
                    return new ServiceResponse<CatalogModel>("Not found");
                return new ServiceResponse<CatalogModel>(catalog);

            }
            return new ServiceResponse<CatalogModel>(answer.StatusCode.ToString());
        }

        public async Task<ServiceResponse<List<CatalogModel>>> FindByAsync(string name)
        {
            var answer = await _httpClient.GetAsync($"{_options.FindCatalogEp}{name}");
            if (answer.IsSuccessStatusCode)
            {
               var catalog = JsonSerializer.Deserialize<List<CatalogModel>>(
                   await answer.Content.ReadAsStringAsync(),
                   SerializeOptions.CamelCase
                   );
                if (catalog == null)
                    return new ServiceResponse<List<CatalogModel>>("Not found");
                return new ServiceResponse<List<CatalogModel>>(catalog);

            }
            return new ServiceResponse<List<CatalogModel>>(answer.StatusCode.ToString());
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var answer = await _httpClient.DeleteAsync($"{_options.DeleteCatalogEp}{id}");
            if (answer.IsSuccessStatusCode)
            {
                return new ServiceResponse();
            }
            return new ServiceResponse(answer.StatusCode.ToString());
        }

        public async Task<ServiceResponse<CatalogModel>> CreateAsync(CatalogModel catalog)
        {       
            var resp = await _httpClient.PostAsJsonAsync(_options.CreateCatalogEp, catalog);

            if (resp.IsSuccessStatusCode)
            {
                var catalogResp = JsonSerializer.Deserialize<CatalogModel>(
                   await resp.Content.ReadAsStringAsync(),
                   SerializeOptions.CamelCase
                   );


                return new ServiceResponse<CatalogModel>(catalogResp!);
            }

            return new ServiceResponse<CatalogModel>(resp.StatusCode.ToString()); 
        }

        public async Task<ServiceResponse<CatalogModel>> EditAsync(CatalogModel catalog)
        {
            var resp = await _httpClient.PutAsJsonAsync(_options.CreateCatalogEp, catalog);

            if (resp.IsSuccessStatusCode)
            {
                var catalogResp = JsonSerializer.Deserialize<CatalogModel>(
                   await resp.Content.ReadAsStringAsync(),
                   SerializeOptions.CamelCase
                   );
                return new ServiceResponse<CatalogModel>(catalogResp!);
            }

            return new ServiceResponse<CatalogModel>(resp.StatusCode.ToString());
        }
    }
}
