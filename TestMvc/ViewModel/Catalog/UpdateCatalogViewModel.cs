using System.ComponentModel.DataAnnotations;
using TestMvc.Models;

namespace TestMvc.ModelView.Catalog
{
    public class UpdateCatalogViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public UpdateCatalogViewModel(CatalogModel catalog)
        {
            Id = catalog.Id;
            Name = catalog.Name;
        }
    }
}
