using Domain.Anemic.Entities;
using Microsoft.EntityFrameworkCore;
using NazmMapping.Mappings;
using System;


namespace ViewModels.TaxOrganizationSales
{
    public class TaxOrganizationSaleEditForSendInputParamsViewModel : IMapFrom<TAX_ORGANIZATION_SALE>
    {
        public int ID { get; set; }
        public double FEE { get; set; }
        public DateTime? INDATIM { get; set; }
    }
}
