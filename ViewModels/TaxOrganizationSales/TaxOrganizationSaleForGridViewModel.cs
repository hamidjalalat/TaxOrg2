using Domain.Anemic.Entities;
using Nazm.Extensions;
using NazmMapping.Mappings;
using System;

namespace ViewModels.TaxOrganizationSales
{
    public class TaxOrganizationSaleForGridViewModel : IMapFrom<TAX_ORGANIZATION_SALE>
    {
        public string ID { get; set; }
        public string TAXID { get; set; }
        public DateTime INDATIM { get; set; }
        public string INDATI2M { get; set; }
        public string INTY { get; set; }
        public string INNO { get; set; }
        //public string IRTAXID { get; set; }
        //public int INP { get; set; }
        public string INS { get; set; }
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
        public string TPRDIS { get; set; }
        public string TDIS { get; set; }
        public string TADIS { get; set; }
        public string TVAM { get; set; }
        public string TODAM { get; set; }
        public string TBILL { get; set; }
        //public string TONW { get; set; }
        //public string TORV { get; set; }
        //public string TOCV { get; set; }
        public int SETM { get; set; }
        public string CAP { get; set; }
        public string INSP { get; set; }
        public string TVOP { get; set; }
        public string TAX17 { get; set; }
        public string SSTID { get; set; }
        public string SSTT { get; set; }
        //public int AM { get; set; }
        //public string MU { get; set; }
        //public string NW { get; set; }
        public string FEE { get; set; }
        public string CFEE { get; set; }
        public string CUT { get; set; }
        public string EXR { get; set; }
        public string SSRV { get; set; }
        public string SSCV { get; set; }
        public string PRDIS { get; set; }
        public string DIS { get; set; }
        public string ADIS { get; set; }
        public string? VRA { get; set; }
        public string VAM { get; set; }
        //public string ODT { get; set; }
        //public string ODR { get; set; }
        //public string ODAM { get; set; }
        //public string OLT { get; set; }
        //public string OLR { get; set; }
        //public string OLAM { get; set; }
        //public string CONSFEE { get; set; }
        //public string SPRO { get; set; }
        //public string BROS { get; set; }
        //public string TCPBS { get; set; }
        //public string COP { get; set; }
        //public string VOP { get; set; }
        //public string BSRN { get; set; }
        public string TSSTAM { get; set; }
        //public string IINN { get; set; }
        //public string CAN { get; set; }
        //public string TRMN { get; set; }
        //public int PMT { get; set; }
        //public string TRN { get; set; }
        //public string PCN { get; set; }
        //public string PID { get; set; }
        //public DateTime PDT { get; set; }
        //public string PV { get; set; }
        public string INSUTP { get; set; }
        public string POLICY_NO { get; set; }
        //public string ELNO { get; set; }
        public string DATM { get; set; }
        public string NEWDATA { get; set; }
        public string STATUS { get; set; }
        public string ERROR_DSC { get; set; }
        public string BRANCH_ID { get; set; }
        public string AGENT_ID { get; set; }
        public string MAPFLDDTLCOD { get; set; }
        public string INVOICE_MODEL { get; set; }
        public string INNO_TYPE { get; set; }
        public string REFERENCE_ID { get; set; }
        public string YEAR { get; set; }
        public string Sort { get; set; }
        public string ISACTIVE { get; set; }
        public string ISSYSTEM { get; set; }
        public string FIELDCODE { get; set; }
        public string INVOICE_MODELID { get; set; }
        public bool IsEdited
        {
            get
            {
                if (INS == "2")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //public bool IsCancel
        //{
        //    get
        //    {
        //        if (INS == "3")
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //}
        public string IndatimDateSH
        {
            get
            {
                return INDATIM.ToPersianDate();
            }
        }
        public string IsActiveTitle
        {
            get { return Utility.GetInstance().getIsActiveTitle(ISACTIVE.ToString()); }
        }
        public bool ShowDelete
        {
            get
            {
                if ((STATUS == "FAILED" || TAXID == null) && INS == 1.ToString())
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
                if ((STATUS == "FAILED" || TAXID == null) && INS == 1.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool ShowCancelAndEditForSend
        {
            get
            {
                if (STATUS == "SUCCESS" && INS == 1.ToString())
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
                string ColorCode = "";

                if (STATUS == "SUCCESS")
                {
                    ColorCode = "success";
                }
                if (STATUS == "FAILED")
                {
                    ColorCode = "danger";
                }
                if (STATUS == "PENDING")
                {
                    ColorCode = "warning";
                }
                if (STATUS == "NOT SEND")
                {
                    ColorCode = "primary";
                }
                if (INS == "3")
                {
                    ColorCode = "dark";
                }
                if (INS == "2")
                {
                    ColorCode = "info";
                }

                return ColorCode;
            }
        }
        public string StatusSH
        {
            get
            {
                string strStatus = "";

                if (STATUS == "SUCCESS")
                {
                    strStatus = "موفق";
                }
                if (STATUS == "FAILED")
                {
                    strStatus = "خطا";
                }
                if (STATUS == "PENDING")
                {
                    strStatus = "در انتظار";
                }
                if (STATUS == "")
                {
                    strStatus = "ارسال نشده";
                }
                if (STATUS == "NOT SEND")
                {
                    strStatus = "در حال ارسال";
                }
                if (INS == "3")
                {
                    strStatus = "ابطالی";
                }
                if (INS == "2")
                {
                    strStatus = "اصلاح شده";
                }

                return strStatus;
            }
        }
    }
}
