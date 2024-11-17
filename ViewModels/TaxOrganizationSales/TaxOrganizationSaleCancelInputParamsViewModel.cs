using Domain.Anemic.Entities;
using Microsoft.EntityFrameworkCore;
using NazmMapping.Mappings;
using System;


namespace ViewModels.TaxOrganizationSales
{
    public class TaxOrganizationSaleCancelInputParamsViewModel : IMapFrom<TAX_ORGANIZATION_SALE>
    {
        public int Id { get; set; }
     
    }
}
