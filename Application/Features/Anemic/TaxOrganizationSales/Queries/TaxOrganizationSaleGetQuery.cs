using Application.Common;
using Application.Common.Extensions;
using Application.Common.Interfaces.Repository.Anemic.Base;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nazm.Results;
using NazmMapping.Mappings;
using ViewModels.Shared;
using ViewModels.TaxOrganizationSales;
using System.Linq.Expressions;
using static Application.Common.GridHelper;

namespace Application.Features.Anemic.TaxOrganizationSales.Queries
{

    public class TaxOrganizationSaleGetQuery : BaseRequest, IRequest<Result<PaginatedList<TaxOrganizationSaleViewModel>>>
    {
        public TaxOrganizationSaleGetQuery()
        {

        }
        public TaxOrganizationSaleGetQuery(PublicViewModel viewModel)
        {
            InputViewModel = viewModel;
        }
        public PublicViewModel InputViewModel { get; private set; }
    }

    public class TaxOrganizationSaleGetQueryHandler : BaseRequestHandler<TaxOrganizationSaleGetQuery, Result<PaginatedList<TaxOrganizationSaleViewModel>>>
    {

        public TaxOrganizationSaleGetQueryHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
        }

        protected async override Task<Result<PaginatedList<TaxOrganizationSaleViewModel>>> HandleRequestAsync(TaxOrganizationSaleGetQuery input, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<PaginatedList<TaxOrganizationSaleViewModel>>();
            var query = _unitOfWork.TaxOrganizationSales.GetAll.OrderByDescending(s => s.ID).AsNoTracking();
            var mapperViewModel = query.ProjectTo<TaxOrganizationSaleViewModel>(_mapper.ConfigurationProvider, cancellationToken);

            if (input.InputViewModel.FilterParams != null && input.InputViewModel.FilterParams.SortBy != null)
            {
                mapperViewModel = mapperViewModel.OrderBy(input.InputViewModel.FilterParams?.SortBy ?? "");
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
                var response = await mapperViewModel
                  .Where(delegateQuery)
                  .PaginatedListAsync(input.InputViewModel.PageNumber, input.InputViewModel.PageSize, cancellationToken);
                return result.WithValue(response).ConvertToDtatResult();
            }
            else
            {
                var TaxOrganizationSaleViewModel = await mapperViewModel
                    .PaginatedListAsync(input.InputViewModel.PageNumber, input.InputViewModel.PageSize, cancellationToken);

                return result.WithValue(TaxOrganizationSaleViewModel).ConvertToDtatResult();
            }
        }
    }
}
