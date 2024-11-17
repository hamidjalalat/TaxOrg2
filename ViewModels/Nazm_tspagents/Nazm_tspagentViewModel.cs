﻿using AutoMapper;
using Domain.Anemic.Entities;
using Microsoft.EntityFrameworkCore;
using NazmMapping.Mappings;
using System;
using ViewModels.Controllers;
using Nazm.Extensions;

namespace ViewModels.Nazm_tspagents

{
    public class Nazm_tspagentViewModel : IMapFrom<Nazm_tspagent>
    {
        public int id { get; set; }
        public DateTime? indati2m { get; set; }
        public decimal tax17 { get; set; }
        public string acn { get; set; }
        public decimal am { get; set; }
        public string bbc { get; set; }
        public string bid { get; set; }
        public string bpc { get; set; }
        public string bpn { get; set; }
        public decimal bros { get; set; }
        public string bsrn { get; set; }
        public decimal cap { get; set; }
        public decimal cfee { get; set; }
        public string consfee { get; set; }
        public string cop { get; set; }
        public string crn { get; set; }
        public string cut { get; set; }
        public decimal dis { get; set; }
        public decimal exr { get; set; }
        public decimal fee { get; set; }
        public string iinn { get; set; }
        public DateTime? indatim { get; set; }
        public long inno { get; set; }
        public int inp { get; set; }
        public int ins { get; set; }
        public int inty { get; set; }
        public string irtaxid { get; set; }
        public string mu { get; set; }
        public string odam { get; set; }
        public string odr { get; set; }
        public string odt { get; set; }
        public decimal olam { get; set; }
        public decimal olr { get; set; }
        public string olt { get; set; }
        public string pcn { get; set; }
        public string pdt { get; set; }
        public string pid { get; set; }
        public string pmt { get; set; }
        public decimal pv { get; set; }
        public string sbc { get; set; }
        public string scc { get; set; }
        public string scln { get; set; }
        public int setm { get; set; }
        public decimal spro { get; set; }
        public decimal sscv { get; set; }
        public decimal ssrv { get; set; }
        public string sstid { get; set; }
        public string sstt { get; set; }
        public string tinb { get; set; }
        public int tob { get; set; }
        public string trmn { get; set; }
        public string trn { get; set; }
        public decimal vra { get; set; }
        public string tins { get; set; }
        public int ft { get; set; }
        public DateTime? input_time { get; set; }
        public int Version { get; set; }
        public int Retry { get; set; }
        public string Address { get; set; }
        public DateTime? Update_Time { get; set; }
        public string TaxId { get; set; }
        public string Status { get; set; }
        public string Reference_Id { get; set; }
        public string Error_Description { get; set; }
        public int Error_Code { get; set; }
        public DateTime? Create_Time { get; set; }
        public int Sort { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InqueryDate { get; set; }
        public int Branch_Id { get; set; }
        public string Agent_Id { get; set; }
        public string Mapfylddtlcod { get; set; }
        public int InvoiceModel_Id { get; set; }
        public int DimProduct_Id { get; set; }
        public int Netsale_Id { get; set; }
        public string Policy_No { get; set; }
        public bool IsEdited
        {
            get
            {
                if (ins == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool IsCancel
        {
            get
            {
                if (ins == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string IndatimDateSH
        {
            get
            {
                return indatim.Value.ToPersianDate();
            }
        }
        public string IsActiveTitle
        {
            get { return Utility.GetInstance().getIsActiveTitle(IsActive.ToString()); }
        }
        public bool ShowEditDelete
        {
            get
            {
                if (TaxId == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool ShowEdit
        {
            get
            {
                if (Status == "SUCCESS")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string StatusColor
        {
            get
            {
                string ColorCode="";

                if (Status == "SUCCESS")
                {
                    ColorCode= "#25d605";
                }
                if (Status == "FAILED")
                {
                    ColorCode= "#e82a1d";
                }
                if (Status == "PENDING")
                {
                    ColorCode= "#c3ed18";
                }
                if (TaxId == null)
                {
                    ColorCode = "#188bed";
                }
                if (ins == 3)
                {
                    ColorCode = "#fd0023";
                }

                return ColorCode;
            }
        }

    }
}
