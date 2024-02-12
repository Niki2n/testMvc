namespace TestMvc.Options
{
    public class ApiOptions
    {
        public static readonly string Section = "ApiConfig";
        public static readonly string ClientName = "ApiClient";
        public string Host { get; set; } = string.Empty;
        public string GetCatalogsEp { get; set; } = string.Empty;
        public string GetCatalogByIdEp { get; set; } = string.Empty;
        public string CreateCatalogEp { get; set; } = string.Empty;
        public string FindCatalogEp { get; set; } = string.Empty;
        public string DeleteCatalogEp { get; set; } = string.Empty;
        public string FindElementEp { get; set; } = string.Empty;

    }
}
