using Application.Common.Interfaces.Repository.Anemic.Oracle;
using Domain.Anemic.Entities;
using Domain.Enums;
using FluentResults;
using Infrastructure.Repository.Anemic.Base;
using Microsoft.EntityFrameworkCore;
using Nazm.Extensions;
using Persistence.Configurations.Anemic.Contexts;
using ViewModels.Invoices;
using ViewModels.TaxOrganizationSales;

namespace Infrastructure.Repository.Anemic.Oracle
{
    public class TaxOrganizationSaleRepository : EFOracleRepository<TAX_ORGANIZATION_SALE>, ITaxOrganizationSaleRepository
    {
        public TaxOrganizationSaleRepository(OracleContext context) : base(context)
        {
            _oracleContext = context;
            _ValidDate = Convert.ToInt32(Resources.DefaultValues.MoadianNumberOfValidDate);
            _reduceNow = DateTime.Now.AddDays(-1 * _ValidDate).Date;
        }
        private int _ValidDate;
        private readonly OracleContext _oracleContext;

        private DateTime _reduceNow;

        public async Task<InquiryFindByInnoViewModel> FindByInnoAsync(long inno)
        {
            return await _oracleContext.TAX_ORGANIZATION_SALES.Where(C => C.INNO == inno.ToString() && C.TAXID == null)
                        .OrderBy(C => C.ID)
                        .Select(s => new InquiryFindByInnoViewModel
                        {
                            id = s.ID,
                            inno = s.INNO,
                            TaxId = s.TAXID,
                            Reference_Id = s.REFERENCE_ID,
                        })
                        .FirstOrDefaultAsync();
        }
        public async Task<int> FindMaxIdAsync()
        {
            return await _oracleContext.TAX_ORGANIZATION_SALES.MaxAsync(C => C.ID);

        }
        public async Task<InquiryFindByInnoViewModel> FindByInnoForCancelInvoiceAsync(long inno)
        {
            return await _oracleContext.TAX_ORGANIZATION_SALES.Where(C => C.INNO == inno.ToString() && C.TAXID != null)
                        .OrderBy(C => C.ID)
                        .Select(s => new InquiryFindByInnoViewModel
                        {
                            id = s.ID,
                            inno = s.INNO,
                            TaxId = s.TAXID,
                            Reference_Id = s.REFERENCE_ID,
                        })
                        .FirstAsync();
        }
        public async Task<InquiryFindByInnoViewModel> FindByInnoForEditInvoiceAsync(long inno)
        {
            return await _oracleContext.TAX_ORGANIZATION_SALES.Where(C => C.INNO == inno.ToString() && C.TAXID != null)
                        .OrderBy(C => C.ID)
                        .Select(s => new InquiryFindByInnoViewModel
                        {
                            id = s.ID,
                            inno = s.INNO,
                            TaxId = s.TAXID,
                            Reference_Id = s.REFERENCE_ID,
                        })
                        .FirstAsync();
        }
        public async Task<InquiryFindByRefrenceViewModel> FindByReferenceIdAsync(string referenceId)
        {
            return await _oracleContext.TAX_ORGANIZATION_SALES.Where(C => C.REFERENCE_ID == referenceId)
                        .OrderBy(C => C.ID)
                        .Select(S => new InquiryFindByRefrenceViewModel
                        {
                            id = S.ID,
                            Status = S.STATUS,
                            Error_Description = S.ERROR_DSC,

                        })
                        .FirstAsync();
        }
        public async Task<long> GetCountInvoice(TaxOrganizationSaleInputDateInvoiceViewModel date)
        {
            return await _oracleContext.TAX_ORGANIZATION_SALES.Where(D => D.YEAR == date.Year).CountAsync();
        }
        public async Task<long> GetCountInvoiceSuccess(TaxOrganizationSaleInputDateInvoiceViewModel date)
        {
            return await _oracleContext.TAX_ORGANIZATION_SALES.Where(C => C.STATUS == "SUCCESS").Where(D => D.YEAR == date.Year).CountAsync();
        }
        public async Task<long> GetCountInvoicePending(TaxOrganizationSaleInputDateInvoiceViewModel date)
        {
            return await _oracleContext.TAX_ORGANIZATION_SALES.Where(C => C.STATUS == "PENDING").Where(D => D.YEAR == date.Year).CountAsync();
        }
        public async Task<long> GetCountInvoiceFailed(TaxOrganizationSaleInputDateInvoiceViewModel date)
        {
            return await _oracleContext.TAX_ORGANIZATION_SALES.Where(C => C.STATUS == "FAILED").Where(D => D.YEAR == date.Year).CountAsync();
        }
        public async Task<long> GetCountInvoiceCancel(TaxOrganizationSaleInputDateInvoiceViewModel date)
        {
            return await _oracleContext.TAX_ORGANIZATION_SALES.Where(C => C.INS == 3).Where(D => D.YEAR == date.Year).CountAsync();
        }
        public async Task<long> GetCountInvoiceSending(TaxOrganizationSaleInputDateInvoiceViewModel date)
        {
            return await _oracleContext.TAX_ORGANIZATION_SALES.Where(C => C.TAXID == null).Where(D => D.YEAR == date.Year).CountAsync();
        }
        public async Task<Result<bool>> IsUnique(TAX_ORGANIZATION_SALE model, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<bool>();
            List<String> errorList = new List<String>();

            #region Add
            if (model.ID == 0)
            {
                var isExist = await GetAll.AnyAsync(s => s.INNO == model.INNO.ToString(), cancellationToken);
                if (isExist)
                {
                    errorList.Add(string.Format(Resources.Messages.Validations.Repetitive, Resources.DataDictionary.Code));
                }

            }
            #endregion

            #region Edit
            if (model.ID > 0)
            {
                var isExist = await GetAll.AnyAsync(s => s.ID != model.ID && s.INNO == model.INNO.ToString(), cancellationToken);
                if (isExist)
                {
                    errorList.Add(string.Format(Resources.Messages.Validations.Repetitive, Resources.DataDictionary.Code));
                }

            }
            #endregion

            if (errorList.Count > 0)
            {
                return result.WithErrors(errorList);
            }
            else
            {
                return result.WithValue(true);
            }
        }
        public IQueryable<TAX_ORGANIZATION_SALE> GetAllByFilter(TaxOrganizationSaleInputParamsViewModel InputParams)
        {
            var Nazm_tspagent = _oracleContext.TAX_ORGANIZATION_SALES.AsQueryable();

            if (InputParams.BranchId != 0)
            {
                Nazm_tspagent = Nazm_tspagent
                    .Where(B => B.BRANCH_ID == InputParams.BranchId);
            }

            if (InputParams.Bid != null)
            {
                Nazm_tspagent = Nazm_tspagent
                    .Where(B => B.BID == InputParams.Bid);
            }

            if (InputParams.Inno != 0)
            {
                Nazm_tspagent = Nazm_tspagent
                    .Where(B => B.INNO == InputParams.Inno.ToString());
            }

            if (InputParams.Tinb != null)
            {
                Nazm_tspagent = Nazm_tspagent
                    .Where(B => B.TINB == InputParams.Tinb);
            }

            if (InputParams.PolicyNo != null)
            {
                Nazm_tspagent = Nazm_tspagent
                    .Where(B => B.POLICY_NO == InputParams.PolicyNo);
            }

            if (InputParams.DimProductId != 0)
            {
                Nazm_tspagent = Nazm_tspagent
                    .Where(B => B.FIELDCODE.ToString() == InputParams.DimProductId.ToString());
            }

            if (InputParams.NetsaleId != null)
            {
                Nazm_tspagent = Nazm_tspagent
                    .Where(B => B.AGENT_ID == InputParams.NetsaleId.ToString());
            }

            if (InputParams.InvoiceModelId != 0)
            {
                Nazm_tspagent = Nazm_tspagent
                    .Where(B => B.INVOICE_MODELID == InputParams.InvoiceModelId);
            }

            if (InputParams.Status == StatusEnum.SUCCESS)
            {
                Nazm_tspagent = Nazm_tspagent
                    .Where(B => B.STATUS == StatusEnum.SUCCESS.ToString());
            }

            if (InputParams.Status == StatusEnum.FAILED)
            {
                Nazm_tspagent = Nazm_tspagent
                    .Where(B => B.STATUS == StatusEnum.FAILED.ToString());
            }

            if (InputParams.Status == StatusEnum.SENDING)
            {
                Nazm_tspagent = Nazm_tspagent
                   .Where(C => C.TAXID == null);
            }

            if (InputParams.Status == StatusEnum.PENDING)
            {
                Nazm_tspagent = Nazm_tspagent
                  .Where(C => C.STATUS == StatusEnum.PENDING.ToString());
            }

            if (InputParams.Status == StatusEnum.CANCEL)
            {
                Nazm_tspagent = Nazm_tspagent
                  .Where(C => C.INS == 3);
            }

            if (InputParams.Status == StatusEnum.EDITFORSEND)
            {
                Nazm_tspagent = Nazm_tspagent
                  .Where(C => C.INS == 2);
            }

            Nazm_tspagent = Nazm_tspagent.Where(C => C.YEAR == InputParams.Year);

            Nazm_tspagent = Nazm_tspagent.Where(C => C.INDATIM >= InputParams.FromDate && C.INDATIM <= InputParams.ToDate);

            var result = Nazm_tspagent/*.Select(s => new TAX_ORGANIZATION_SALE //TaxOrganizationSaleForGridViewModel
            {
                ID = s.ID,
                STATUS = s.STATUS,
                INNO = s.INNO,
                FEE = s.FEE,
                DIS = s.DIS,
                TDIS = s.TDIS,
                VRA = s.VRA,
                TINS = s.TINS,
                BID = s.BID,
                TOB = (int)s.TOB,
                TINB = s.TINB,
                BPC = s.BPC,
                SSTID = s.SSTID,
                SSTT = s.SSTT,
                TAXID = s.TAXID,
                REFERENCE_ID = s.REFERENCE_ID,
                POLICY_NO = s.POLICY_NO,
                BRANCH_ID = s.BRANCH_ID,
                INVOICE_MODEL = s.INVOICE_MODEL,
                AGENT_ID = s.AGENT_ID,
                FIELDCODE = s.FIELDCODE,
                SETM = (int)s.SETM,
                INTY = s.INTY.Value,
                INS = s.INS,
                ERROR_DSC = s.ERROR_DSC,
                INDATIM = s.INDATIM,
            }
            )*/.OrderByDescending(I => I.ID).AsNoTracking();

            return result;

        }
        public TAX_ORGANIZATION_SALE DeleteTAX_ORGANIZATION_SALE(TAX_ORGANIZATION_SALE Entity)
        {
            _oracleContext.Remove(Entity);
            _oracleContext.SaveChanges();

            return Entity;
        }
        public TAX_ORGANIZATION_SALE UpdateOracle(TAX_ORGANIZATION_SALE Entity)
        {
            _oracleContext.Update(Entity);
            _oracleContext.SaveChanges();

            return Entity;
        }
        public TAX_ORGANIZATION_SALE InsertTAX_ORGANIZATION_SALE(TAX_ORGANIZATION_SALE Entity)
        {
            _oracleContext.Add(Entity);
            _oracleContext.SaveChanges();

            return Entity;
        }

    }
}
