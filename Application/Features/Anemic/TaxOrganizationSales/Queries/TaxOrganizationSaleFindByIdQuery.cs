using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.EF;
using Application.Common.Interfaces.Repository.Anemic.Oracle;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nazm.Results;
using NazmMapping.Mappings;
using ViewModels.TaxOrganizationSales;

namespace Application.Features.Anemic.TaxOrganizationSales.Queries
{

    public class TaxOrganizationSaleFindByIdQuery : BaseRequest, IRequest<Result<TaxOrganizationSaleViewModel>>
    {
        public TaxOrganizationSaleFindByIdQuery()
        {

        }
        public TaxOrganizationSaleFindByIdQuery(int id)
        {
          
            Id = id;
        }
        public int Id { get; set; }

    }

    public class TaxOrganizationSaleGetByIdQueryHandler : BaseRequestHandler<TaxOrganizationSaleFindByIdQuery, Result<TaxOrganizationSaleViewModel>>
    {
        private readonly ITaxOrganizationSaleRepository _TaxOrganizationSaleRepository;


        public TaxOrganizationSaleGetByIdQueryHandler(ITaxOrganizationSaleRepository TaxOrganizationSaleRepository,IMapper mapper,IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            _TaxOrganizationSaleRepository = TaxOrganizationSaleRepository;
        }

        protected async override Task<Result<TaxOrganizationSaleViewModel>> HandleRequestAsync(TaxOrganizationSaleFindByIdQuery input, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<TaxOrganizationSaleViewModel>();

            var response = await _unitOfWork.TaxOrganizationSales.FindByIdAsync(input.Id, cancellationToken);

            var TaxOrganizationSaleViewModel = _mapper.Map<TaxOrganizationSaleViewModel>(response);

            return result.WithValue(TaxOrganizationSaleViewModel).ConvertToDtatResult();
        }
    }
}
