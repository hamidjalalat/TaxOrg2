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
    public class TaxOrganizationSaleGetCountInvoiceSuccessQuery : BaseRequest, IRequest<Result<long>>
    {
        private TaxOrganizationSaleGetCountInvoiceSuccessQuery()
        {

        }
        public TaxOrganizationSaleGetCountInvoiceSuccessQuery(TaxOrganizationSaleInputDateInvoiceViewModel viewModel)
        {
         
            InputViewModel = viewModel;
        }
       
        public TaxOrganizationSaleInputDateInvoiceViewModel InputViewModel { get; private set; }

    }

    public class TaxOrganizationSaleGetCountInvoiceSuccessQueryHandler : BaseRequestHandler<TaxOrganizationSaleGetCountInvoiceSuccessQuery, Result<long>>
    {
        private readonly ITaxOrganizationSaleRepository _TaxOrganizationSaleRepository;


        public TaxOrganizationSaleGetCountInvoiceSuccessQueryHandler(ITaxOrganizationSaleRepository TaxOrganizationSaleRepository,IMapper mapper,IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            _TaxOrganizationSaleRepository = TaxOrganizationSaleRepository;
        }

        protected async override Task<Result<long>> HandleRequestAsync(TaxOrganizationSaleGetCountInvoiceSuccessQuery input, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<long>();

            var query = _TaxOrganizationSaleRepository.GetCountInvoiceSuccess(input.InputViewModel);

            return result.WithValue(query.Result).ConvertToDtatResult();

        }
    }
}
