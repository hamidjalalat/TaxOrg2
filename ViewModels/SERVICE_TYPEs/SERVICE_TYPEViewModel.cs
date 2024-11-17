using Domain.Anemic.Entities;
using NazmMapping.Mappings;

namespace ViewModels.SERVICE_TYPEs
{
    public class SERVICE_TYPEViewModel : IMapFrom<SERVICE_TYPE>
    {
        public int ID { get; set; }
        public long SSTID { get; set; }
        public string SSTT { get; set; }
        public double VRA { get; set; }
        public int FIELDCODE { get; set; }
        public string FULLNAME
        {
            get
            {
                return SSTID.ToString() + " - " + SSTT.ToString();
            }
        }
    }
}
