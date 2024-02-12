using System.ComponentModel.DataAnnotations;

namespace TestMvc.Models
{
    public class CatalogModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public List<ElementModel> Elements { get; set; } = [];
    }
}
