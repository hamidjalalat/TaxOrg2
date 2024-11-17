using Application.Common;
using Application.Common.Extensions;
using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.EF;
using Application.Common.Security;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nazm.Results;
using NazmMapping.Mappings;
using System.Linq.Expressions;
using ViewModels;
using ViewModels.TaxOrganizationSales;
using ViewModels.Shared;
using static Application.Common.GridHelper;
using Application.Common.Interfaces.Repository.Anemic.Oracle;

namespace Application.Features.Anemic.TaxOrganizationSales.Queries
{
    public class TaxOrganizationSaleGetCountInvoicePendingQuery : BaseRequest, IRequest<Result<long>>
    {
        private TaxOrganizationSaleGetCountInvoicePendingQuery()
        {

        }
        public TaxOrganizationSaleGetCountInvoicePendingQuery(TaxOrganizationSaleInputDateInvoiceViewModel viewModel)
        {
         
            InputViewModel = viewModel;
        }
       
        public TaxOrganizationSaleInputDateInvoiceViewModel InputViewModel { get; private set; }

    }

    public class TaxOrganizationSaleGetCountInvoicePendingQueryHandler : BaseRequestHandler<TaxOrganizationSaleGetCountInvoicePendingQuery, Result<long>>
    {
        private readonly ITaxOrganizationSaleRepository _TaxOrganizationSaleRepository;


        public TaxOrganizationSaleGetCountInvoicePendingQueryHandler(ITaxOrganizationSaleRepository TaxOrganizationSaleRepository,IMapper mapper,IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            _TaxOrganizationSaleRepository = TaxOrganizationSaleRepository;
        }

        protected async override Task<Result<long>> HandleRequestAsync(TaxOrganizationSaleGetCountInvoicePendingQuery input, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<long>();

            var query = _TaxOrganizationSaleRepository.GetCountInvoicePending(input.InputViewModel);

            return result.WithValue(query.Result).ConvertToDtatResult();

        }
    }
}
