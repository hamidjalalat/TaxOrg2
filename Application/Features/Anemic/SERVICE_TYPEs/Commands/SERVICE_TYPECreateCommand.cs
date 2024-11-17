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

namespace Application.Features.Anemic.SERVICE_TYPEs.Commands
{
    public class SERVICE_TYPECreateCommand : BaseRequest, IRequest<Result<SERVICE_TYPEViewModel>>
    {
        public SERVICE_TYPECreateViewModel SERVICE_TYPEViewModel { get; set; }

    }

    public class SERVICE_TYPECreateCommandHandler : BaseRequestHandler<SERVICE_TYPECreateCommand, Result<SERVICE_TYPEViewModel>>
    {
        private readonly ISERVICE_TYPERepository _SERVICE_TYPERepository;

        public SERVICE_TYPECreateCommandHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            ISERVICE_TYPERepository SERVICE_TYPERepository) : base(unitOfWork, mapper)
        {
            _SERVICE_TYPERepository = SERVICE_TYPERepository;
        }

        protected override async Task<Result<SERVICE_TYPEViewModel>> HandleRequestAsync(SERVICE_TYPECreateCommand input, CancellationToken cancellationToken)
        {
            try
            {
                
                var response = new FluentResults.Result<SERVICE_TYPEViewModel>();
                await _unitOfWork.BeginTransaction(cancellationToken);
                var model = _mapper.Map<SERVICE_TYPE>(input.SERVICE_TYPEViewModel);
                var isUnique = await _unitOfWork.SERVICE_TYPEs.IsUnique(model, cancellationToken);
                if (isUnique.IsSuccess)
                {
                    _unitOfWork.SERVICE_TYPEs.InsertSERVICE_TYPE(model);
                    await _unitOfWork.Commit(cancellationToken);
                    await _unitOfWork.CommitTransaction(cancellationToken);
                    var viewModel = _mapper.Map<SERVICE_TYPEViewModel>(model);
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
