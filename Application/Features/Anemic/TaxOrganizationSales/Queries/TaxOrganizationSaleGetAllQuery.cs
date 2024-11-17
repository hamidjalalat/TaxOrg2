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
    public class TaxOrganizationSaleGetAllQuery : BaseRequest, IRequest<Result<PaginatedList<TaxOrganizationSaleViewModel>>>
    {
        private TaxOrganizationSaleGetAllQuery()
        {

        }
        public TaxOrganizationSaleGetAllQuery(PublicViewModel viewModel)
        {
       
            InputViewModel = viewModel;
        }
        public PublicViewModel InputViewModel { get; private set; }

    }

    public class TaxOrganizationSaleGetAllQueryHandler : BaseRequestHandler<TaxOrganizationSaleGetAllQuery, Result<PaginatedList<TaxOrganizationSaleViewModel>>>
    {
        private readonly ITaxOrganizationSaleRepository _TaxOrganizationSaleRepository;

        public TaxOrganizationSaleGetAllQueryHandler( ITaxOrganizationSaleRepository TaxOrganizationSaleRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            _TaxOrganizationSaleRepository = TaxOrganizationSaleRepository;
        }

        protected async override Task<Result<PaginatedList<TaxOrganizationSaleViewModel>>> HandleRequestAsync(TaxOrganizationSaleGetAllQuery input, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<PaginatedList<TaxOrganizationSaleViewModel>>();

            var query = _unitOfWork.TaxOrganizationSales.GetAll.OrderByDescending(s => s.ID).AsNoTracking();

            var viewModel = query.ProjectTo<TaxOrganizationSaleViewModel>(_mapper.ConfigurationProvider, cancellationToken);

            if (input.InputViewModel.FilterParams != null && input.InputViewModel.FilterParams.SortBy != null)
            {
                viewModel = viewModel.OrderBy(input.InputViewModel.FilterParams?.SortBy ?? "");
            }

            if (input.InputViewModel.FilterParams != null && input.InputViewModel.FilterParams.Filter != null && input.InputViewModel.FilterParams.Filter.Count > 0)
            {
                var filters = new List<Filter>();

                foreach (var item in input.InputViewModel.FilterParams.Filter)
                {
                    filters.Add(new Filter()
                    {
                        Operator = item.Operator.ToLower().GetOperator(),
                        PropertyName = item.Field,
                        Value = item.Value,
                    });
                }

                Expression<Func<TaxOrganizationSaleViewModel, bool>> delegateQuery = ExpressionBuilder.GetExpression<TaxOrganizationSaleViewModel>(filters);

                var response = await viewModel
                    .Where(delegateQuery)
                  .PaginatedListAsync(input.InputViewModel.PageNumber, input.InputViewModel.PageSize, cancellationToken);

                return result.WithValue(response).ConvertToDtatResult();
            }

            else
            {
                var TaxOrganizationSaleViewModel = await viewModel
                     .PaginatedListAsync(input.InputViewModel.PageNumber, input.InputViewModel.PageSize, cancellationToken);

                return result.WithValue(TaxOrganizationSaleViewModel).ConvertToDtatResult();
            }

        }
    }
}
