using Domain.Anemic.Common;

namespace Domain.Anemic.Entities
{
    public class Product: BaseEntity
    {

        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
