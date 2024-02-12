namespace TestMvc.Models
{
    public class ElementModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTime Data { get; set; } = default;
    }
}
