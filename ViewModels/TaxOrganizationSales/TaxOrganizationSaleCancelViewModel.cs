using Domain.Anemic.Entities;
using NazmMapping.Mappings;
using System;

namespace ViewModels.TaxOrganizationSales
{
    public class TaxOrganizationSaleCancelViewModel : IMapFrom<TAX_ORGANIZATION_SALE>
    {
        public int ID { get; set; }
        public string TAXID { get; set; }
        public DateTime INDATIM { get; set; }
        public string IRTAXID { get; set; }
        public string INNO { get; set; }
        public int INS { get; set; }
        public int DATM { get; set; }
        public int NEWDATA { get; set; }
        public string STATUS { get; set; }
        public string REFERENCE_ID { get; set; }
    }
}
