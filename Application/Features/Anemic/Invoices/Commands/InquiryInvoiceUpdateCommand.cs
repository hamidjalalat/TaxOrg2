using AutoMapper;
using Domain.Anemic.Entities;
using MediatR;
using Nazm.Results;
using ViewModels.Invoices;
using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common;
using System.Text;

namespace Application.Features.Anemic.Invoices.Commands
{
    public class InquiryInvoiceUpdateCommand : BaseRequest, IRequest<Result<string>>
    {
        public InvoiceUpdateViewModel InvoiceViewModel { get; set; }

    }

    public class InquiryInvoiceUpdateCommandHandler : BaseRequestHandler<InquiryInvoiceUpdateCommand, Result<string>>
    {

        public InquiryInvoiceUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, InquiryService inquiryService) : base(unitOfWork, mapper)
        {
            _inquiryService = inquiryService;
        }

        private readonly InquiryService _inquiryService;

        protected override async Task<Result<string>> HandleRequestAsync(InquiryInvoiceUpdateCommand input, CancellationToken cancellationToken)
        {
            try
            {
                string outputMessage = string.Empty;

                var result = new FluentResults.Result<string>();

                outputMessage = "Get:S,";

                var listInqueryByReferenceId = await _unitOfWork.Nazm_tspagents.GetAllByFilterForInQuery(take: 100);

                outputMessage += "Get:F,";

                if (listInqueryByReferenceId.Count == 0)
                    return result.WithError(Resources.Messages.Common.CalcRecordEmptyText).ConvertToDtatResult();

                List<InquiryViewModel> response = null;

                outputMessage += "Tiss:S,";

                try
                {
                    response = await _inquiryService.PostAsync(listInqueryByReferenceId, input.InvoiceViewModel.Token, input.InvoiceViewModel.XOrgId);
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

                int intCount = response.Count;
                

                for (int i = 0; i < intCount; i++)
                {
                    InquiryViewModel responseInquiryViewModel = response[i];
                    if (responseInquiryViewModel != null && responseInquiryViewModel.ReferenceNumber != null)
                    {
                        outputMessage += "FindBYRef:S,";
                        var nazm_tspagent = await _unitOfWork.Nazm_tspagents.FindByReferenceIdAsync(responseInquiryViewModel.ReferenceNumber);
                        outputMessage += "FindBYRef:F,";

                        StringBuilder Messages = new StringBuilder();

                        foreach (var item in responseInquiryViewModel.Data.Error)
                        {
                            Messages.AppendLine(item.Message);
                        }

                        nazm_tspagent.Status = responseInquiryViewModel.Status;

                        nazm_tspagent.Error_Description = Messages.ToString().Length > 512 ? Messages.ToString().Substring(1, 512) : Messages.ToString();

                        nazm_tspagent.InqueryDate = Nazm.DateTime.Now;

                        Nazm_tspagent entity = new Nazm_tspagent()
                        {
                            id = nazm_tspagent.id,
                            Status = nazm_tspagent.Status,
                            Error_Description = Messages.ToString(),
                            InqueryDate = Nazm.DateTime.Now
                        };

                        outputMessage += "Update:S,";
                        _unitOfWork.Nazm_tspagents.UpdateSpecificField(entity, x => x.Status, x => x.Error_Description, x => x.InqueryDate);
                        outputMessage += "Update:F,";

                        outputMessage += "UnitOfWorkCommit:S,";
                        await _unitOfWork.Commit(cancellationToken);
                        outputMessage += "UnitOfWorkCommit:F,";
                    }
                }

                return result.WithValue($"{response.Count()} rows affected; " + outputMessage).ConvertToDtatResult();

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransaction(cancellationToken);

                throw;
            }

        }
    }
}
