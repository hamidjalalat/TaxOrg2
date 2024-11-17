using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.Oracle;
using AutoMapper;
using Domain.Anemic.Entities;
using MediatR;
using Nazm.Results;
using NazmMapping.Mappings;

namespace Application.Features.Anemic.TaxOrganizationSales.Commands
{
    public class TaxOrganizationSaleDeleteCommand : BaseRequest, IRequest<Result<bool>>, IMapFrom<TAX_ORGANIZATION_SALE>
    {
        public TaxOrganizationSaleDeleteCommand()
        {

        }
        public TaxOrganizationSaleDeleteCommand(int id)
        {
            TaxOrganizationSaleId = id;
        }
        public int TaxOrganizationSaleId { get; set; }
    }

    public class TaxOrganizationSaleDeleteCommandHandler : BaseRequestHandler<TaxOrganizationSaleDeleteCommand, Result<bool>>
    {
        private readonly ITaxOrganizationSaleRepository _TaxOrganizationSaleRepository;

        public TaxOrganizationSaleDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ITaxOrganizationSaleRepository TaxOrganizationSaleRepository) : base(unitOfWork, mapper)
        {
            _TaxOrganizationSaleRepository = TaxOrganizationSaleRepository;
        }

        protected override async Task<Result<bool>> HandleRequestAsync(TaxOrganizationSaleDeleteCommand input, CancellationToken cancellationToken)
        {
            bool result = false;

            var response = new FluentResults.Result<bool>();

            try
            {
                await _unitOfWork.BeginTransaction(cancellationToken);

                var model = await _unitOfWork.TaxOrganizationSales.FindByIdAsync(input.TaxOrganizationSaleId,cancellationToken);

                if (model != null)
                    _unitOfWork.TaxOrganizationSales.DeleteTAX_ORGANIZATION_SALE(model);

                await _unitOfWork.Commit(cancellationToken, isDeleted: true);

                await _unitOfWork.CommitTransaction(cancellationToken);

                response.WithSuccess(string.Format(Resources.Messages.Successes.Success, $"{Resources.Buttons.Delete}"));

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
