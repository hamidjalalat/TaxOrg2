using AutoMapper;
using Domain.Anemic.Entities;
using MediatR;
using Nazm.Results;
using ViewModels.SERVICE_TYPEs;
using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.EF;
using Application.Common.Interfaces.Repository.Anemic.Oracle;
using Application.Features.Anemic.SERVICE_TYPEs.Commands;
using NazmMapping.Mappings;
using Application.Features.Anemic.SERVICE_TYPEs.Commands;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Anemic.SERVICE_TYPEs.Commands
{
    public class SERVICE_TYPEDeleteCommand : BaseRequest, IRequest<Result<bool>>, IMapFrom<SERVICE_TYPE>
    {
        public SERVICE_TYPEDeleteCommand()
        {

        }
        public SERVICE_TYPEDeleteCommand(int id)
        {
            SERVICE_TYPEId = id;
        }
        public int SERVICE_TYPEId { get; set; }
    }

    public class SERVICE_TYPEDeleteCommandHandler : BaseRequestHandler<SERVICE_TYPEDeleteCommand, Result<bool>>
    {
        private readonly ISERVICE_TYPERepository _SERVICE_TYPERepository;

        public SERVICE_TYPEDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISERVICE_TYPERepository SERVICE_TYPERepository) : base(unitOfWork, mapper)
        {
            _SERVICE_TYPERepository = SERVICE_TYPERepository;
        }

        protected override async Task<Result<bool>> HandleRequestAsync(SERVICE_TYPEDeleteCommand input, CancellationToken cancellationToken)
        {
            bool result = false;
            var response = new FluentResults.Result<bool>();
            try
            {
                await _unitOfWork.BeginTransaction(cancellationToken);
                var model = await _SERVICE_TYPERepository.FindByIdAsync(input.SERVICE_TYPEId, cancellationToken);
                if (model != null)
                {
                    //var taxOrganizationSales = await _unitOfWork.TaxOrganizationSales.GetAll.Where(s => s.SSTID == model.SSTID.ToString()).ToListAsync(cancellationToken);
                    //if (taxOrganizationSales.Count > 0)
                    //{
                    //    return response
                    //            .WithError(Resources.Messages.Errors.DependentTables)
                    //            .ConvertToDtatResult();
                    //}
                    //else
                    //{
                    _unitOfWork.SERVICE_TYPEs.DeleteSERVICE_TYPE(model);
                    response
                        .WithSuccess(string.Format(Resources.Messages.Successes.Success, $"{Resources.Buttons.Delete}"));
                    //}
                }
                await _unitOfWork.Commit(cancellationToken, isDeleted: true);
                await _unitOfWork.CommitTransaction(cancellationToken);
                result = true;
            }
            catch (Exception)
            {
                result = false;
                await _unitOfWork.RollbackTransaction(cancellationToken);
                throw;
            }
            return response
                    .WithValue(result)
                    .ConvertToDtatResult();
        }
    }
}
