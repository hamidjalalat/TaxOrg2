using Application.Common.Exceptions;
using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.EF;
using Application.Common.Interfaces.Repository.Anemic.Oracle;
using AutoMapper;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Domain.Anemic.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nazm.Extensions;
using Nazm.Results;
using NazmMapping.Mappings;
using ViewModels.TaxOrganizationSales;

namespace Application.Features.Anemic.TaxOrganizationSales.Commands
{
    public class TaxOrganizationSaleEditForSendCommand : BaseRequest, IRequest<Result<bool>>
    {
        public TaxOrganizationSaleEditForSendInputParamsViewModel InputViewModel { get; set; }

    }

    public class TaxOrganizationSaleEditForSendCommandHandler : BaseRequestHandler<TaxOrganizationSaleEditForSendCommand, Result<bool>>
    {
        private readonly ITaxOrganizationSaleRepository _TaxOrganizationSaleRepository;

        public TaxOrganizationSaleEditForSendCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ITaxOrganizationSaleRepository TaxOrganizationSaleRepository) : base(unitOfWork, mapper)
        {
            _TaxOrganizationSaleRepository = TaxOrganizationSaleRepository;
        }

        protected override async Task<Result<bool>> HandleRequestAsync(TaxOrganizationSaleEditForSendCommand input, CancellationToken cancellationToken)
        {
            var response = new FluentResults.Result<bool>();
            List<string> errorList = new List<string>();

            bool result = false;

            try
            {
                var entity = await _unitOfWork.TaxOrganizationSales.FindByIdAsync(input.InputViewModel.ID, cancellationToken);

                string _INNO_New = entity.INNO.Trim() + "2";

                if (entity == null)
                {
                    errorList.Add(Resources.Messages.Errors.RecordEmpty);
                }
                else
                {
                    await _unitOfWork.BeginTransaction(cancellationToken);

                    entity.INS = 2;
                    entity.INNO = _INNO_New;
                    //entity.INDATIM = DateTime.Now.Date;
                    entity.INDATIM = input.InputViewModel.INDATIM.Value.Date;
                    entity.FEE = input.InputViewModel.FEE;
                    entity.TPRDIS = input.InputViewModel.FEE;
                    entity.TADIS = input.InputViewModel.FEE;
                    entity.TBILL = input.InputViewModel.FEE;
                    entity.PRDIS = input.InputViewModel.FEE;
                    entity.ADIS = input.InputViewModel.FEE;
                    entity.TSSTAM = input.InputViewModel.FEE;
                    
                    entity.VAM = input.InputViewModel.FEE * entity.VRA * 0.01;
                    entity.TVAM = input.InputViewModel.FEE * entity.VRA * 0.01;
                    
                    entity.STATUS = "NOT SEND";
                    entity.DATM = Convert.ToInt32(input.InputViewModel.INDATIM.Value.Date.ToPersianDate().Replace("/", ""));
                    entity.NEWDATA = Convert.ToInt32(input.InputViewModel.INDATIM.Value.Date.ToPersianDate().Replace("/", ""));
                    entity.IRTAXID = entity.TAXID;
                    entity.TAXID = "";
                    entity.REFERENCE_ID = "";
                    
                    _unitOfWork.TaxOrganizationSales.UpdateOracle(entity);

                    await _unitOfWork.Commit(cancellationToken);
                    await _unitOfWork.CommitTransaction(cancellationToken);

                }

                var viewModel = _mapper.Map<TaxOrganizationSaleCancelViewModel>(entity);

                response.WithSuccess(string.Format(Resources.Messages.Successes.Success, $"{Resources.DataDictionary.EDITFORSEND}"));

                result = true;

            }
            catch (Exception)
            {
                errorList.Add(string.Format(Resources.Messages.Errors.Error, $"{Resources.DataDictionary.EDITFORSEND}"));
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
                        .WithSuccess(string.Format(Resources.Messages.Successes.Success, $"{Resources.DataDictionary.EDITFORSEND}"))
                        .WithValue(result)
                        .ConvertToDtatResult();
            }

        }
    }
}
