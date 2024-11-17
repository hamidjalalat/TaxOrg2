using AutoMapper;
using Domain.Anemic.Entities;
using MediatR;
using Nazm.Results;
using ViewModels.TaxOrganizationSales;
using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.EF;
using Application.Common.Interfaces.Repository.Anemic.Oracle;
using Application.Features.Anemic.SERVICE_TYPEs.Commands;
using ViewModels.SERVICE_TYPEs;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Anemic.SERVICE_TYPEs.Commands
{
    public class SERVICE_TYPEUpdateCommand : BaseRequest, IRequest<Result<SERVICE_TYPEUpdateViewModel>>
    {
        public SERVICE_TYPEUpdateViewModel SERVICE_TYPEViewModel { get; set; }

    }

    public class UpdateSERVICE_TYPECommandHandler : BaseRequestHandler<SERVICE_TYPEUpdateCommand, Result<SERVICE_TYPEUpdateViewModel>>
    {
        private readonly ISERVICE_TYPERepository _SERVICE_TYPERepository;

        public UpdateSERVICE_TYPECommandHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            ISERVICE_TYPERepository SERVICE_TYPERepository) : base(unitOfWork, mapper)
        {
            _SERVICE_TYPERepository = SERVICE_TYPERepository;
        }

        protected override async Task<Result<SERVICE_TYPEUpdateViewModel>> HandleRequestAsync(SERVICE_TYPEUpdateCommand input, CancellationToken cancellationToken)
        {
            try
            {
                var response = new FluentResults.Result<SERVICE_TYPEUpdateViewModel>();
                await _unitOfWork.BeginTransaction(cancellationToken);
                var entity = await _unitOfWork.SERVICE_TYPEs.GetAll.Where(s => s.ID == input.SERVICE_TYPEViewModel.ID).SingleOrDefaultAsync(cancellationToken);

                if (entity == null)
                {
                    return response
                         .WithError(Resources.Messages.Errors.RecordEmpty)
                         .ConvertToDtatResult();
                }
                var model = _mapper.Map(input.SERVICE_TYPEViewModel, entity);
                var isUnique = await _unitOfWork.SERVICE_TYPEs.IsUnique(model, cancellationToken);
                if (isUnique.IsSuccess)
                {
                    _unitOfWork.SERVICE_TYPEs.UpdateSERVICE_TYPE(model);
                    await _unitOfWork.Commit(cancellationToken);
                    await _unitOfWork.CommitTransaction(cancellationToken);
                    var viewModel = _mapper.Map<SERVICE_TYPEUpdateViewModel>(model);
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
