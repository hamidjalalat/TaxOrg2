using Domain.Anemic.Entities;
using Nazm.Extensions;
using NazmMapping.Mappings;
using System;


namespace ViewModels.TaxOrganizationSales
{
    public class TaxOrganizationSaleActiveViewModel : IMapFrom<TAX_ORGANIZATION_SALE>
    {
        public int ID { get; set; }
        public string TAXID { get; set; }
        public DateTime INDATIM { get; set; }
        public int INDATI2M { get; set; }
        public int INTY { get; set; }
        public string INNO { get; set; }
        public int IRTAXID { get; set; }
        public int INP { get; set; }
        public int INS { get; set; }
        public string TINS { get; set; }
        public string TINB { get; set; }
        public int TOB { get; set; }
        public int SBC { get; set; }
        public string BID { get; set; }
        public string BPC { get; set; }
        public int BBC { get; set; }
        public string BPN { get; set; }
        public int FT { get; set; }
        public int SCLN { get; set; }
        public int SCC { get; set; }
        public int CRN { get; set; }
        public string CDCN { get; set; }
        public int CDCD { get; set; }
        public string BILLID { get; set; }
        public int TPRDIS { get; set; }
        public double TDIS { get; set; }
        public double TADIS { get; set; }
        public int TVAM { get; set; }
        public int TODAM { get; set; }
        public int TBILL { get; set; }
        public double TONW { get; set; }
        public double TORV { get; set; }
        public double TOCV { get; set; }
        public int SETM { get; set; }
        public double CAP { get; set; }
        public double INSP { get; set; }
        public double TVOP { get; set; }
        public double TAX17 { get; set; }
        public string SSTID { get; set; }
        public string SSTT { get; set; }
        public int AM { get; set; }
        public string MU { get; set; }
        public string NW { get; set; }
        public int FEE { get; set; }
        public string CFEE { get; set; }
        public string CUT { get; set; }
        public string EXR { get; set; }
        public string SSRV { get; set; }
        public string SSCV { get; set; }
        public int PRDIS { get; set; }
        public int DIS { get; set; }
        public int ADIS { get; set; }
        public int VRA { get; set; }
        public int VAM { get; set; }
        public string ODT { get; set; }
        public string ODR { get; set; }
        public string ODAM { get; set; }
        public string OLT { get; set; }
        public string OLR { get; set; }
        public string OLAM { get; set; }
        public string CONSFEE { get; set; }
        public string SPRO { get; set; }
        public string BROS { get; set; }
        public string TCPBS { get; set; }
        public string COP { get; set; }
        public string VOP { get; set; }
        public string BSRN { get; set; }
        public int TSSTAM { get; set; }
        public string IINN { get; set; }
        public string CAN { get; set; }
        public string TRMN { get; set; }
        public string PMT { get; set; }
        public string TRN { get; set; }
        public string PCN { get; set; }
        public string PID { get; set; }
        public string PDT { get; set; }
        public string PV { get; set; }
        public int INSUTP { get; set; }
        public string POLICY_NO { get; set; }
        public string ELNO { get; set; }
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

		public string IndatimDateSH
        {
            get
            {
                return INDATIM.ToPersianDate();
            }
        }
    }
}
