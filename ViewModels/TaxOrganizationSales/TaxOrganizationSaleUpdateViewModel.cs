using Domain.Anemic.Entities;
using Microsoft.EntityFrameworkCore;
using NazmMapping.Mappings;
using System;


namespace ViewModels.TaxOrganizationSales
{
    public class TaxOrganizationSaleUpdateViewModel:IMapFrom<TAX_ORGANIZATION_SALE>
    {
        public int ID { get; set; }
        public DateTime? INDATIM { get; set; }
        //public int? INDATI2M { get; set; } = 0; // AllData
        public int INTY { get; set; }
        public string INNO { get; set; }
        //public int INP { get; set; } = 1; // AllData
        //public int INS { get; set; } = 1; // AllData
        //public string TINS { get; set; } = "10103858742";
        public string TINB { get; set; }
        public int TOB { get; set; }
        public string BID { get; set; }
        public string BPC { get; set; }
        public double? TPRDIS
        {
            get
            {
                return FEE;
            }
            set
            {
                value = FEE;
            }
        }
        //public double? TDIS { get; set; } = 0; // AllData
        public double? TADIS
        {
            get
            {
                return FEE;
            }
            set
            {
                value = FEE;
            }
        }
        public double? TVAM
        {
            get
            {
                return FEE * VRA / 100.0;
            }
            set
            {
                value = FEE * VRA / 100.0;
            }
        }

        //public double? TODAM { get; set; } = 0; // AllData
        public double? TBILL
        {
            get
            {
                return FEE;
            }
            set
            {
                value = FEE;
            }
        }

        public int? SETM { get; set; }
        //public double? CAP { get; set; } = 0; // AllData
        //public double? INSP { get; set; } = 0; // AllData
        //public double? TVOP { get; set; } = 0; // AllData
        //public double? TAX17 { get; set; } = 0; // AllData
        public string SSTID { get; set; }
        public string SSTT { get; set; }
        //public double? AM { get; set; } = 1; // AllData

        public double FEE { get; set; }

        public double? PRDIS
        {
            get
            {
                return FEE;
            }
            set
            {
                value = FEE;
            }
        }
        public double? DIS { get; set; }
        public double? ADIS
        {
            get
            {
                return FEE;
            }
            set
            {
                value = FEE;
            }
        }
        public double? VRA { get; set; }
        public double? VAM
        {
            get
            {
                return FEE * VRA / 100.0;
            }
            set
            {
                value = FEE * VRA / 100.0;
            }
        }

        public double? TSSTAM
        {
            get
            {
                return FEE;
            }
            set
            {
                value = FEE;
            }
        }

        public int? INSUTP { get; set; } // نوع بیمه نامه 

        public string POLICY_NO { get; set; }
        public int DATM { get; set; }
        public int NEWDATA { get; set; }

        //public string STATUS { get; set; } = "NOT SEND";

        public int BRANCH_ID { get; set; } // NUMBER                   145
        public string AGENT_ID { get; set; } //VARCHAR2(1020 BYTE)      31496
        public string MAPFLDDTLCOD { get; set; } //VARCHAR2(81 BYTE)    5_1
        public string INVOICE_MODEL { get; set; } //CHAR(15 BYTE)       Sales          
        public int INNO_TYPE
        {
            get
            {
                return INVOICE_MODELID;
            }
            set
            {
                value = INVOICE_MODELID;
            }
        }
        public int YEAR { get; set; }
        //public int ISACTIVE { get; set; } = 1; // NUMBER

        //public int ISSYSTEM { get; set; } = 0;
        public int FIELDCODE { get; set; }
        public int INVOICE_MODELID { get; set; }


        /* Value Null
            IRTAXID 
            SBC
            BBC 
            BPN
            FT 
            SCLN
            SCC 
            CRN
            CDCN 
            CDCD
            BILLID 
            TONW
            TORV 
            TOCV
            MU 
            NW
            CFEE 
            CUT
            EXR 
            SSRV
            SSCV 
            ODT
            ODR 
            ODAM
            OLT 
            OLR
            OLAM 
            CONSFEE
            SPRO 
            BROS
            TCPBS 
            COP
            VOP 
            BSRN
            IINN 
            CAN
            TRMN 
            PMT
            TRN 
            PCN
            PID 
            PDT
            PV 
            ELNO
        */

    }
}
