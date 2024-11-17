using NazmMapping.Mappings;
using Domain.Anemic.Entities;

namespace ViewModels.SERVICE_TYPEs
{
    public class SERVICE_TYPECreateViewModel : IMapFrom<SERVICE_TYPE>
    {
        public long SSTID { get; set; }
        public string SSTT { get; set; }
        public double VRA { get; set; }
        public int FIELDCODE { get; set; }

    }
}
