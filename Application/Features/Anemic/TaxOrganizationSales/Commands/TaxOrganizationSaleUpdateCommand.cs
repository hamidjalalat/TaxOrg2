using Application.Common.Exceptions;
using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.EF;
using Application.Common.Interfaces.Repository.Anemic.Oracle;
using AutoMapper;
using Domain.Anemic.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nazm.Results;
using NazmMapping.Mappings;
using ViewModels.TaxOrganizationSales;

namespace Application.Features.Anemic.TaxOrganizationSales.Commands
{
    public class TaxOrganizationSaleUpdateCommand : BaseRequest, IRequest<Result<TaxOrganizationSaleUpdateViewModel>>
    {
        public TaxOrganizationSaleUpdateViewModel TaxOrganizationSaleViewModel { get; set; }

    }

    public class UpdateTaxOrganizationSaleCommandHandler : BaseRequestHandler<TaxOrganizationSaleUpdateCommand, Result<TaxOrganizationSaleUpdateViewModel>>
    {
        private readonly ITaxOrganizationSaleRepository _TaxOrganizationSaleRepository;

        public UpdateTaxOrganizationSaleCommandHandler(IUnitOfWork unitOfWork,IMapper mapper, ITaxOrganizationSaleRepository TaxOrganizationSaleRepository) : base(unitOfWork, mapper)
        {
            _TaxOrganizationSaleRepository = TaxOrganizationSaleRepository;
        }

        protected override async Task<Result<TaxOrganizationSaleUpdateViewModel>> HandleRequestAsync(TaxOrganizationSaleUpdateCommand input, CancellationToken cancellationToken)
        {
            try
            {
                var response = new FluentResults.Result<TaxOrganizationSaleUpdateViewModel>();

                await _unitOfWork.BeginTransaction(cancellationToken);

                var entity = await _unitOfWork.TaxOrganizationSales.GetAll.Where(s => s.ID == input.TaxOrganizationSaleViewModel.ID).SingleOrDefaultAsync(cancellationToken);

                if (entity == null)
                {
                    return response
                         .WithError(Resources.Messages.Errors.RecordEmpty)
                         .ConvertToDtatResult();
                }

                var model = _mapper.Map(input.TaxOrganizationSaleViewModel, entity);

                var isUnique = await _unitOfWork.TaxOrganizationSales.IsUnique(model, cancellationToken);

                if (isUnique.IsSuccess)
                {
                    _unitOfWork.TaxOrganizationSales.UpdateOracle(model);

                    await _unitOfWork.Commit(cancellationToken);
                    await _unitOfWork.CommitTransaction(cancellationToken);

                    var viewModel = _mapper.Map<TaxOrganizationSaleUpdateViewModel>(model);

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
