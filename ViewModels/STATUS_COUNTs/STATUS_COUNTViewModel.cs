using Domain.Anemic.Entities;
using NazmMapping.Mappings;

namespace ViewModels.STATUS_COUNTs
{
    public class STATUS_COUNTViewModel : IMapFrom<STATUS_COUNT>
    {
		//public int ID { get; set; }
        public int YEAR { get; set; }
        public string STATUS { get; set; }
        public int SCOUNT { get; set; }
    }
}
