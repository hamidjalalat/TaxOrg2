using Domain.Anemic.Entities;
using Nazm.Extensions;
using NazmMapping.Mappings;
using System;
using System.Net;

namespace ViewModels.TaxOrganizationSales
{
    public class TaxOrganizationSaleViewModel : IMapFrom<TAX_ORGANIZATION_SALE>
    {
        public int ID { get; set; }
        public string TAXID { get; set; }
        public DateTime INDATIM { get; set; }
        public int INDATI2M { get; set; }
        public int INTY { get; set; }
        public string INNO { get; set; }
        //public string IRTAXID { get; set; }
        //public int INP { get; set; }
        public int INS { get; set; }
        public string TINS { get; set; }
        public string TINB { get; set; }
        public int TOB { get; set; }
        //public string SBC { get; set; }
        public string BID { get; set; }
        public string BPC { get; set; }
        //public string BBC { get; set; }
        //public string BPN { get; set; }
        //public int FT { get; set; }
        //public string SCLN { get; set; }
        //public string SCC { get; set; }
        //public string CRN { get; set; }
        //public string CDCN { get; set; }
        //public int CDCD { get; set; }
        //public string BILLID { get; set; }
        public double TPRDIS { get; set; }
        public double TDIS { get; set; }
        public double TADIS { get; set; }
        public double TVAM { get; set; }
        public double TODAM { get; set; }
        public double TBILL { get; set; }
        //public double TONW { get; set; }
        //public double TORV { get; set; }
        //public double TOCV { get; set; }
        public int SETM { get; set; }
        public double CAP { get; set; }
        public double INSP { get; set; }
        public double TVOP { get; set; }
        public double TAX17 { get; set; }
        public string SSTID { get; set; }
        public string SSTT { get; set; }
        //public int AM { get; set; }
        //public string MU { get; set; }
        //public double NW { get; set; }
        public double FEE { get; set; }
        public double CFEE { get; set; }
        public string CUT { get; set; }
        public double EXR { get; set; }
        public double SSRV { get; set; }
        public double SSCV { get; set; }
        public double PRDIS { get; set; }
        public double DIS { get; set; }
        public double ADIS { get; set; }
        public double? VRA { get; set; }
        public double VAM { get; set; }
        //public string ODT { get; set; }
        //public double ODR { get; set; }
        //public double ODAM { get; set; }
        //public string OLT { get; set; }
        //public double OLR { get; set; }
        //public double OLAM { get; set; }
        //public double CONSFEE { get; set; }
        //public double SPRO { get; set; }
        //public double BROS { get; set; }
        //public double TCPBS { get; set; }
        //public double COP { get; set; }
        //public double VOP { get; set; }
        //public string BSRN { get; set; }
        public double TSSTAM { get; set; }
        //public string IINN { get; set; }
        //public string CAN { get; set; }
        //public string TRMN { get; set; }
        //public int PMT { get; set; }
        //public string TRN { get; set; }
        //public string PCN { get; set; }
        //public string PID { get; set; }
        //public DateTime PDT { get; set; }
        //public double PV { get; set; }
        public int INSUTP { get; set; }
        public string POLICY_NO { get; set; }
        //public string ELNO { get; set; }
        public int DATM { get; set; }
        public int NEWDATA { get; set; }
        public string STATUS { get; set; }
        public string ERROR_DSC { get; set; }
        public int BRANCH_ID { get; set; }
        public string AGENT_ID { get; set; }
        public string MAPFLDDTLCOD { get; set; }
        public string INVOICE_MODEL { get; set; }
        public int INNO_TYPE { get; set; }
        public string REFERENCE_ID { get; set; }
        public int YEAR { get; set; }
        public int Sort { get; set; }
        public int ISACTIVE { get; set; }
        public int ISSYSTEM { get; set; }
        public int FIELDCODE { get; set; }
        public int INVOICE_MODELID { get; set; }

    }
}
