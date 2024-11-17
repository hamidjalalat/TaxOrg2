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
using ViewModels.Products;
using System.Linq.Expressions;
using static Application.Common.GridHelper;

namespace Application.Features.Anemic.Products.Queries
{

    public class ProductGetQuery : BaseRequest, IRequest<Result<PaginatedList<ProductViewModel>>>
    {
        public ProductGetQuery()
        {

        }
        public ProductGetQuery(PublicViewModel viewModel)
        {
            InputViewModel = viewModel;
        }
        public PublicViewModel InputViewModel { get; private set; }
    }

    public class ProductGetQueryHandler : BaseRequestHandler<ProductGetQuery, Result<PaginatedList<ProductViewModel>>>
    {

        public ProductGetQueryHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
        }

        protected async override Task<Result<PaginatedList<ProductViewModel>>> HandleRequestAsync(ProductGetQuery input, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<PaginatedList<ProductViewModel>>();
            var query = _unitOfWork.Products.GetAll.OrderByDescending(s => s.ProductId).AsNoTracking();
            var mapperViewModel = query.ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider, cancellationToken);

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
                Expression<Func<ProductViewModel, bool>> delegateQuery = ExpressionBuilder.GetExpression<ProductViewModel>(filters);
                var response = await mapperViewModel
                  .Where(delegateQuery)
                  .PaginatedListAsync(input.InputViewModel.PageNumber, input.InputViewModel.PageSize, cancellationToken);
                return result.WithValue(response).ConvertToDtatResult();
            }
            else
            {
                var ProductViewModel = await mapperViewModel
                    .PaginatedListAsync(input.InputViewModel.PageNumber, input.InputViewModel.PageSize, cancellationToken);

                return result.WithValue(ProductViewModel).ConvertToDtatResult();
            }
        }
    }
}
