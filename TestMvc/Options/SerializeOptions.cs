using System.Text.Json;

namespace TestMvc.Options
{
    public static class SerializeOptions
    {
        public static readonly JsonSerializerOptions CamelCase = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
}
