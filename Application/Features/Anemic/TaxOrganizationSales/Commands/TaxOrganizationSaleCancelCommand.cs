using Application.Common.Extensions;
using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.EF;
using Application.Common.Interfaces.Repository.Anemic.Oracle;
using AutoMapper;
using Domain.Anemic.Entities;
using MediatR;
using Nazm.Results;
using NazmMapping.Mappings;
using ViewModels.SERVICE_TYPEs;
using ViewModels.TaxOrganizationSales;

namespace Application.Features.Anemic.TaxOrganizationSales.Commands
{
    public class TaxOrganizationSaleCancelCommand : BaseRequest, IRequest<Result<bool>>
    {
        public TaxOrganizationSaleCancelCommand()
        {

        }
        public TaxOrganizationSaleCancelCommand(int id)
        {
            TaxOrganizationSaleId = id;
        }
        public int TaxOrganizationSaleId { get; set; }
    }

    public class TaxOrganizationSaleCancelCommandHandler : BaseRequestHandler<TaxOrganizationSaleCancelCommand, Result<bool>>
    {
        private readonly ITaxOrganizationSaleRepository _TaxOrganizationSaleRepository;

        public TaxOrganizationSaleCancelCommandHandler(IUnitOfWork unitOfWork,
                        IMapper mapper,
                        ITaxOrganizationSaleRepository TaxOrganizationSaleRepository) : base(unitOfWork, mapper)
        {
            _TaxOrganizationSaleRepository = TaxOrganizationSaleRepository;
        }

        protected override async Task<Result<bool>> HandleRequestAsync(TaxOrganizationSaleCancelCommand input, CancellationToken cancellationToken)
        {

            var response = new FluentResults.Result<bool>();
            List<string> errorList = new List<string>();

            bool result = false;

            try
            {

                /*
                await _unitOfWork.BeginTransactionOracle(cancellationToken);

                var taxOrganizationSales = await _unitOfWork.TaxOrganizationSales.FindByIdAsync(input.TaxOrganizationSaleId,cancellationToken);

                TAX_ORGANIZATION_SALE entity = new TAX_ORGANIZATION_SALE()
                {
                    INS = 3,
                    INNO = taxOrganizationSales.INNO + "00",
                    INDATIM = DateTime.Now.Date,
                    STATUS = "NOT SEND",
                    DATM = Convert.ToInt32(DateTime.Now.Date.ToPersianDate().Replace("/", "")),
                    NEWDATA = Convert.ToInt32(DateTime.Now.Date.ToPersianDate().Replace("/", "")),
                    IRTAXID = taxOrganizationSales.TAXID,
                    TAXID = "",
                    REFERENCE_ID = "",
                };

                _unitOfWork.TaxOrganizationSales.UpdateSpecificField(entity, x => x.INS, x => x.INNO, x => x.INDATIM, 
                                                                             x => x.STATUS, x => x.DATM, x => x.NEWDATA, 
                                                                             x => x.IRTAXID, x => x.TAXID, x => x.REFERENCE_ID);


                response.WithSuccess(string.Format(Resources.Messages.Successes.Success, $"{Resources.DataDictionary.Cancel}"));

                await _unitOfWork.CommitOracle(cancellationToken);
                await _unitOfWork.CommitTransactionOracle(cancellationToken);
                */

                var entity = await _unitOfWork.TaxOrganizationSales.FindByIdAsync(input.TaxOrganizationSaleId, cancellationToken);

                string _INNO_New = entity.INNO.Trim() + "3";

                if (entity == null)
                {
                    errorList.Add(Resources.Messages.Errors.RecordEmpty);
                }
                else
                {
                    await _unitOfWork.BeginTransaction(cancellationToken);

                    entity.INS = 3;
                    entity.INNO = _INNO_New;
                    entity.INDATIM = DateTime.Now.Date;
                    entity.STATUS = "NOT SEND";
                    entity.DATM = Convert.ToInt32(DateTime.Now.Date.ToPersianDate().Replace("/", ""));
                    entity.NEWDATA = Convert.ToInt32(DateTime.Now.Date.ToPersianDate().Replace("/", ""));
                    entity.IRTAXID = entity.TAXID;
                    entity.TAXID = "";
                    entity.REFERENCE_ID = "";

                    _unitOfWork.TaxOrganizationSales.UpdateOracle(entity);

                    await _unitOfWork.Commit(cancellationToken);
                    await _unitOfWork.CommitTransaction(cancellationToken);

                }

                var viewModel = _mapper.Map<TaxOrganizationSaleCancelViewModel>(entity);

                response.WithSuccess(string.Format(Resources.Messages.Successes.Success, $"{Resources.DataDictionary.Cancel}"));

                result = true;

            }
            catch (Exception)
            {
                errorList.Add(string.Format(Resources.Messages.Errors.Error, $"{Resources.DataDictionary.Cancel}"));
                await _unitOfWork.RollbackTransaction(cancellationToken);
            }

            if (errorList.Count > 0)
            {
                return response
                        .WithErrors(errorList)
                        .ConvertToDtatResult();
            }
            else
            {
                return response
                        .WithSuccess(string.Format(Resources.Messages.Successes.Success, $"{Resources.DataDictionary.Cancel}"))
                        .WithValue(result)
                        .ConvertToDtatResult();
            }
        }
    }
}
