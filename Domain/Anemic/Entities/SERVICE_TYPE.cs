using Domain.Anemic.Common;

namespace Domain.Anemic.Entities
{
    public class SERVICE_TYPE : BaseEntity
    {
		public int ID { get; set; }
        public long SSTID { get; set; }
        public string SSTT { get; set; }
        public double VRA { get; set; }
        public int FIELDCODE { get; set; }
    }
}
