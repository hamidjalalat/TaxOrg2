using Domain.Anemic.Entities;
using NazmMapping.Mappings;

namespace ViewModels.Products
{
    public class ProductViewModel : IMapFrom<Product>
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
