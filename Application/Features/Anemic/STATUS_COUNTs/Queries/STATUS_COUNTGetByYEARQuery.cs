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
using ViewModels.STATUS_COUNTs;
using ViewModels.Shared;
using static Application.Common.GridHelper;
using Application.Common.Interfaces.Repository.Anemic.Oracle;
using Application.Features.Anemic.STATUS_COUNTs.Queries;

namespace Application.Features.Anemic.STATUS_COUNTs.Queries
{
    public class STATUS_COUNTGetByYEARQuery : BaseRequest, IRequest<Result<PaginatedList<STATUS_COUNTViewModel>>>
    {
        private STATUS_COUNTGetByYEARQuery()
        {

        }
        public STATUS_COUNTGetByYEARQuery(STATUS_COUNTInputParamsViewModel viewModel)
        {

            InputViewModel = viewModel;
        }
        public STATUS_COUNTInputParamsViewModel InputViewModel { get; private set; }

    }

    public class STATUS_COUNTGetAllQueryHandler : BaseRequestHandler<STATUS_COUNTGetByYEARQuery, Result<PaginatedList<STATUS_COUNTViewModel>>>
    {
        private readonly ISTATUS_COUNTRepository _STATUS_COUNTRepository;

        public STATUS_COUNTGetAllQueryHandler(ISTATUS_COUNTRepository STATUS_COUNTRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            _STATUS_COUNTRepository = STATUS_COUNTRepository;
        }

        protected async override Task<Result<PaginatedList<STATUS_COUNTViewModel>>> HandleRequestAsync(STATUS_COUNTGetByYEARQuery input, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<PaginatedList<STATUS_COUNTViewModel>>();

            var query = _unitOfWork.STATUS_COUNTs.GetAll
                            .Where(s=>s.YEAR == input.InputViewModel.YEAR)
                            .OrderByDescending(s => s.STATUS)
                            .AsNoTracking();

            var viewModel = query.ProjectTo<STATUS_COUNTViewModel>(_mapper.ConfigurationProvider, cancellationToken);

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

                Expression<Func<STATUS_COUNTViewModel, bool>> delegateQuery = ExpressionBuilder.GetExpression<STATUS_COUNTViewModel>(filters);

                var response = await viewModel
                    .Where(delegateQuery)
                  .PaginatedListAsync(input.InputViewModel.PageNumber, input.InputViewModel.PageSize, cancellationToken);

                return result.WithValue(response).ConvertToDtatResult();
            }

            else
            {
                var STATUS_COUNTViewModel = await viewModel
                     .PaginatedListAsync(input.InputViewModel.PageNumber, input.InputViewModel.PageSize, cancellationToken);

                return result.WithValue(STATUS_COUNTViewModel).ConvertToDtatResult();
            }

        }
    }
}
