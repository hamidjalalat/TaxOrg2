using AutoMapper;
using Domain.Anemic.Entities;
using MediatR;
using Nazm.Results;
using ViewModels.TaxOrganizationSales;
using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.EF;
using Application.Common.Interfaces.Repository.Anemic.Oracle;


namespace Application.Features.Anemic.TaxOrganizationSales.Commands
{
    public class TaxOrganizationSaleCreateCommand : BaseRequest, IRequest<Result<TaxOrganizationSaleViewModel>>
    {
        public TaxOrganizationSaleCreateViewModel TaxOrganizationSaleViewModel { get; set; }

    }

    public class TaxOrganizationSaleCreateCommandHandler : BaseRequestHandler<TaxOrganizationSaleCreateCommand, Result<TaxOrganizationSaleViewModel>>
    {
        private readonly ITaxOrganizationSaleRepository _TaxOrganizationSaleRepository;

        public TaxOrganizationSaleCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,ITaxOrganizationSaleRepository TaxOrganizationSaleRepository) : base(unitOfWork, mapper)
        {
            _TaxOrganizationSaleRepository = TaxOrganizationSaleRepository;
        }

        protected override async Task<Result<TaxOrganizationSaleViewModel>> HandleRequestAsync(TaxOrganizationSaleCreateCommand input, CancellationToken cancellationToken)
        {
            try
            {
                var response = new FluentResults.Result<TaxOrganizationSaleViewModel>();

                await _unitOfWork.BeginTransaction(cancellationToken);

                var model = _mapper.Map<TAX_ORGANIZATION_SALE>(input.TaxOrganizationSaleViewModel);

                var isUnique = await _unitOfWork.TaxOrganizationSales.IsUnique(model, cancellationToken);

                if (isUnique.IsSuccess)
                {

                    _unitOfWork.TaxOrganizationSales.InsertTAX_ORGANIZATION_SALE(model);

                    await _unitOfWork.Commit(cancellationToken);
                    await _unitOfWork.CommitTransaction(cancellationToken);

                    var viewModel = _mapper.Map<TaxOrganizationSaleViewModel>(model);

                    return response
                        .WithSuccess(string.Format(Resources.Messages.Successes.Success, $"{Resources.Buttons.Save}"))
                        .WithValue(viewModel)
                        .ConvertToDtatResult();
                }
                else
                {
                    return response
                        .WithErrors(isUnique.Errors)
                        .ConvertToDtatResult();
                }
                
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction(cancellationToken);
                throw;
            }

        }
    }
}
