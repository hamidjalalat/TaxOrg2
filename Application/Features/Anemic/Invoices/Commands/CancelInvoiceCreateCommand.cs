using AutoMapper;
using Domain.Anemic.Entities;
using MediatR;
using Nazm.Results;
using ViewModels.Invoices;
using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common;

namespace Application.Features.Anemic.Invoices.Commands
{
    public class CancelInvoiceCreateCommand : BaseRequest, IRequest<Result<string>>
    {
        public InvoiceCreateViewModel InvoiceViewModel { get; set; }

    }

    public class CancelInvoiceCreateCommandHandler : BaseRequestHandler<CancelInvoiceCreateCommand, Result<string>>
    {

        public CancelInvoiceCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, InvoiceService InvoiceService) : base(unitOfWork, mapper)
        {
            _InvoiceService = InvoiceService;

        }
        private readonly InvoiceService _InvoiceService;

        protected override async Task<Result<string>> HandleRequestAsync(CancelInvoiceCreateCommand input, CancellationToken cancellationToken)
        {
            try
            {
                string outputMessage = string.Empty;

                var result = new FluentResults.Result<string>();

                outputMessage = "Get:S,";

                var listNazm_tspagents = await _unitOfWork.Nazm_tspagents.GetAllByFilterForCancelInvoice(100);

                outputMessage += "Get:F,";

                if (listNazm_tspagents.Count == 0)
                    return result.WithError(Resources.Messages.Common.CalcRecordEmptyText).ConvertToDtatResult();

                outputMessage += "ObjSet:S,";

                ToObjectConversion objectSet = new ToObjectConversion();

                var listInvoiceViewModel = objectSet.GetCancelInvoiceSetToObject(listNazm_tspagents);

                outputMessage += "ObjSet:F,";

                List<InvoiceViewModel> response = null;

                outputMessage += "Tiss:S,";

                try
                {
                    response = await _InvoiceService.PostAsync(listInvoiceViewModel, input.InvoiceViewModel.Token, input.InvoiceViewModel.XOrgId);
                }
                catch (Exception)
                {
                    return result.WithError(Resources.Messages.Errors.CalcTissError + " Error Tiss").ConvertToDtatResult();
                }

                outputMessage += "Tiss:F,";

                if (response == null)
                {
                    return result.WithError(Resources.Messages.Errors.CalcTissError + " Error Tiss Null").ConvertToDtatResult();
                }

                int RecourdCount = response.Count;


                for (int i = 0; i < RecourdCount; i++)
                {
                    int _id = listNazm_tspagents.FirstOrDefault(s => s.Inno == response[i].Inno).id;

                    Nazm_tspagent entity = new Nazm_tspagent()
                    {
                        id = _id,
                        Reference_Id = response[i].ReferenceNumber,
                        InqueryDate = null
                    };

                    outputMessage += "UpdateS:S,";
                    _unitOfWork.Nazm_tspagents.UpdateSpecificField(entity, x => x.Reference_Id, x => x.InqueryDate);
                    outputMessage += "UpdateS:F,";

                    outputMessage += "UnitOfWorkCommit:S,";
                    await _unitOfWork.Commit(cancellationToken);
                    outputMessage += "UnitOfWorkCommit:F,";
                }

                return result.WithValue($"{response.Count()} rows affected" + outputMessage).ConvertToDtatResult();

            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction(cancellationToken);

                throw;
            }

        }


    }
}
