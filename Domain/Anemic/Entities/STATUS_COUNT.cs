using Domain.Anemic.Common;

namespace Domain.Anemic.Entities
{
    public class STATUS_COUNT : BaseEntity
    {
		public int ID { get; set; }
        public int YEAR { get; set; }
        public string STATUS { get; set; }
        public int SCOUNT { get; set; }
    }
}
