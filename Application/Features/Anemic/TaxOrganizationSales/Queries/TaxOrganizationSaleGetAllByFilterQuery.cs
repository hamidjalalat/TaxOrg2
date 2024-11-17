using Application.Common;
using Application.Common.Extensions;
using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.EF;
using Application.Common.Interfaces.Repository.Anemic.Oracle;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nazm.Results;
using NazmMapping.Mappings;
using System.Linq.Expressions;
using ViewModels.TaxOrganizationSales;
using static Application.Common.GridHelper;

namespace Application.Features.Anemic.TaxOrganizationSales.Queries
{
    public class TaxOrganizationSaleGetAllByFilterQuery : BaseRequest, IRequest<Result<PaginatedList<TaxOrganizationSaleForGridViewModel>>>
    {
        private TaxOrganizationSaleGetAllByFilterQuery()
        {

        }
        public TaxOrganizationSaleGetAllByFilterQuery(TaxOrganizationSaleInputParamsViewModel viewModel)
        {
            InputViewModel = viewModel;
        }
        public TaxOrganizationSaleInputParamsViewModel InputViewModel { get; private set; }

    }

    public class TaxOrganizationSaleGetAllByFilterQueryHandler : BaseRequestHandler<TaxOrganizationSaleGetAllByFilterQuery, Result<PaginatedList<TaxOrganizationSaleForGridViewModel>>>
    {
        private readonly ITaxOrganizationSaleRepository _TaxOrganizationSaleRepository;


        public TaxOrganizationSaleGetAllByFilterQueryHandler(ITaxOrganizationSaleRepository TaxOrganizationSaleRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            _TaxOrganizationSaleRepository = TaxOrganizationSaleRepository;
        }

        protected async override Task<Result<PaginatedList<TaxOrganizationSaleForGridViewModel>>> HandleRequestAsync(TaxOrganizationSaleGetAllByFilterQuery input, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<PaginatedList<TaxOrganizationSaleForGridViewModel>>();

            var query = _unitOfWork.TaxOrganizationSales.GetAllByFilter(input.InputViewModel);

            var viewModel = query.ProjectTo<TaxOrganizationSaleForGridViewModel>(_mapper.ConfigurationProvider, cancellationToken);

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

                Expression<Func<TaxOrganizationSaleForGridViewModel, bool>> delegateQuery = ExpressionBuilder.GetExpression<TaxOrganizationSaleForGridViewModel>(filters);

                var response = await viewModel
                  .Where(delegateQuery)
                  .PaginatedListAsync(input.InputViewModel.PageNumber, input.InputViewModel.PageSize, cancellationToken);

                return result.WithValue(response).ConvertToDtatResult();
            }

            else
            {
                var TaxOrganizationSaleForGridViewModel = await viewModel
                      .PaginatedListAsync(input.InputViewModel.PageNumber, input.InputViewModel.PageSize, cancellationToken);

                return result.WithValue(TaxOrganizationSaleForGridViewModel).ConvertToDtatResult();
            }

        }
    }
}
