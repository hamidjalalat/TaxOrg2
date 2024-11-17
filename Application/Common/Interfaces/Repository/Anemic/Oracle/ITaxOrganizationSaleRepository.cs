using Application.Common.Interfaces.Repository.Anemic.Base;
using Domain.Anemic.Entities;
using Domain.Enums;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Invoices;
using ViewModels.Nazm_tspagents;
using ViewModels.TaxOrganizationSales;

namespace Application.Common.Interfaces.Repository.Anemic.Oracle
{
    public interface ITaxOrganizationSaleRepository : IRepository<TAX_ORGANIZATION_SALE>
    {

        Task<InquiryFindByInnoViewModel> FindByInnoAsync(long inno);

         Task<InquiryFindByInnoViewModel> FindByInnoForCancelInvoiceAsync(long inno);

         Task<InquiryFindByInnoViewModel> FindByInnoForEditInvoiceAsync(long inno);

         Task<InquiryFindByRefrenceViewModel> FindByReferenceIdAsync(string referenceId);

         Task<long> GetCountInvoice(TaxOrganizationSaleInputDateInvoiceViewModel date);

        Task<long> GetCountInvoiceSuccess(TaxOrganizationSaleInputDateInvoiceViewModel date);

        Task<long> GetCountInvoicePending(TaxOrganizationSaleInputDateInvoiceViewModel date);

        Task<long> GetCountInvoiceFailed(TaxOrganizationSaleInputDateInvoiceViewModel date);


        Task<long> GetCountInvoiceCancel(TaxOrganizationSaleInputDateInvoiceViewModel date);

        Task<long> GetCountInvoiceSending(TaxOrganizationSaleInputDateInvoiceViewModel date);

        Task<Result<bool>> IsUnique(TAX_ORGANIZATION_SALE model, CancellationToken cancellationToken);

        IQueryable<TAX_ORGANIZATION_SALE> GetAllByFilter(TaxOrganizationSaleInputParamsViewModel InputParams);

        TAX_ORGANIZATION_SALE DeleteTAX_ORGANIZATION_SALE(TAX_ORGANIZATION_SALE Entity);

        TAX_ORGANIZATION_SALE UpdateOracle(TAX_ORGANIZATION_SALE Entity);

        TAX_ORGANIZATION_SALE InsertTAX_ORGANIZATION_SALE(TAX_ORGANIZATION_SALE Entity);

        Task<int> FindMaxIdAsync();
    }
}
