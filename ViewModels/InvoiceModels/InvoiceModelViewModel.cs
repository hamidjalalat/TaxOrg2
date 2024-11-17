﻿using AutoMapper;
using Domain.Anemic.Entities;
using Microsoft.EntityFrameworkCore;
using NazmMapping.Mappings;
using System;
using ViewModels.Controllers;

namespace ViewModels.InvoiceModels

{
    public class InvoiceModelViewModel : IMapFrom<InvoiceModel>
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public bool IsActive { get; set; }
        public string IsActiveTitle
        {
            get { return Utility.GetInstance().getIsActiveTitle(IsActive.ToString()); }
        }
        public int INSUTP { get; set; }
        public string LatinName { get; set; }
    }
}
