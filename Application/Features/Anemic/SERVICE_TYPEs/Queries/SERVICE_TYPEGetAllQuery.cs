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
using ViewModels.SERVICE_TYPEs;
using ViewModels.Shared;
using static Application.Common.GridHelper;
using Application.Common.Interfaces.Repository.Anemic.Oracle;
using Application.Features.Anemic.SERVICE_TYPEs.Queries;

namespace Application.Features.Anemic.SERVICE_TYPEs.Queries
{
    public class SERVICE_TYPEGetAllQuery : BaseRequest, IRequest<Result<PaginatedList<SERVICE_TYPEViewModel>>>
    {

        private SERVICE_TYPEGetAllQuery()
        {

        }
        public SERVICE_TYPEGetAllQuery(PublicViewModel viewModel)
        {

            InputViewModel = viewModel;
        }
        public PublicViewModel InputViewModel { get; private set; }

    }

    public class SERVICE_TYPEGetAllQueryHandler : BaseRequestHandler<SERVICE_TYPEGetAllQuery, Result<PaginatedList<SERVICE_TYPEViewModel>>>
    {
        private readonly ISERVICE_TYPERepository _SERVICE_TYPERepository;

        public SERVICE_TYPEGetAllQueryHandler(ISERVICE_TYPERepository SERVICE_TYPERepository, IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            _SERVICE_TYPERepository = SERVICE_TYPERepository;
        }

        protected async override Task<Result<PaginatedList<SERVICE_TYPEViewModel>>> HandleRequestAsync(SERVICE_TYPEGetAllQuery input, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<PaginatedList<SERVICE_TYPEViewModel>>();

            var query = _unitOfWork.SERVICE_TYPEs.GetAll
                            .OrderByDescending(s => s.SSTT)
                            .AsNoTracking();

            var viewModel = query.ProjectTo<SERVICE_TYPEViewModel>(_mapper.ConfigurationProvider, cancellationToken);

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

                Expression<Func<SERVICE_TYPEViewModel, bool>> delegateQuery = ExpressionBuilder.GetExpression<SERVICE_TYPEViewModel>(filters);

                var response = await viewModel
                    .Where(delegateQuery)
                  .PaginatedListAsync(input.InputViewModel.PageNumber, input.InputViewModel.PageSize, cancellationToken);

                return result.WithValue(response).ConvertToDtatResult();
            }

            else
            {
                var SERVICE_TYPEViewModel = await viewModel
                     .PaginatedListAsync(input.InputViewModel.PageNumber, input.InputViewModel.PageSize, cancellationToken);

                return result.WithValue(SERVICE_TYPEViewModel).ConvertToDtatResult();
            }

        }
    }
}
