﻿using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Shared;

namespace ViewModels.TaxOrganizationSales
{
    public class TaxOrganizationSaleInputParamsViewModel:PublicViewModel
    {
        public int? BranchId { get; set; }
        public int? Year { get; set; } 
        public int? NetsaleId { get; set; }
        public int? DimProductId { get; set; }
        public int? InvoiceModelId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public long? Inno { get; set; }
        public string Bid { get; set; }
        public string Tinb { get; set; }
        public string PolicyNo { get; set; }
        public StatusEnum Status { get; set; }
    }
}
