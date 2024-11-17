﻿using Application.Common.Exceptions;
using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.EF;
using AutoMapper;
using Domain.Anemic.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nazm.Results;
using NazmMapping.Mappings;
using ViewModels.Nazm_tspagents;

namespace Application.Features.Anemic.Nazm_tspagents.Commands
{
    public class Nazm_tspagentEditForSendCommand : BaseRequest, IRequest<Result<Nazm_tspagentEditForSendViewModel>>
    {
        public Nazm_tspagentEditForSendViewModel Nazm_tspagentEditForSendViewModel { get; set; }

    }

    public class Nazm_tspagentEditForSendCommandHandler : BaseRequestHandler<Nazm_tspagentEditForSendCommand, Result<Nazm_tspagentEditForSendViewModel>>
    {
        private readonly INazm_tspagentRepository _Nazm_tspagentRepository;

        public Nazm_tspagentEditForSendCommandHandler(IUnitOfWork unitOfWork,IMapper mapper, INazm_tspagentRepository Nazm_tspagentRepository) : base(unitOfWork, mapper)
        {
            _Nazm_tspagentRepository = Nazm_tspagentRepository;
        }

        protected override async Task<Result<Nazm_tspagentEditForSendViewModel>> HandleRequestAsync(Nazm_tspagentEditForSendCommand input, CancellationToken cancellationToken)
        {
            try
            {
                var response = new FluentResults.Result<Nazm_tspagentEditForSendViewModel>();

                await _unitOfWork.BeginTransaction(cancellationToken);

                var entity = await _unitOfWork.Nazm_tspagents.FindByIdAsync( input.Nazm_tspagentEditForSendViewModel.id,cancellationToken);

                if (entity == null)
                {
                    return response
                         .WithError(Resources.Messages.Errors.RecordEmpty)
                         .ConvertToDtatResult();
                }

                var model = _mapper.Map(input.Nazm_tspagentEditForSendViewModel, entity);

                    model.ins = 2;
				    string convertInno = model.inno.ToString() + "00";
				    model.inno = Convert.ToInt64(convertInno);
				    model.indatim = DateTime.Now.Date;
				    model.irtaxid = model.TaxId;
				    model.TaxId = "";
				    model.Status = "SUCCESS";

				_unitOfWork.Nazm_tspagents.Update(model);

                    await _unitOfWork.Commit(cancellationToken);
                    await _unitOfWork.CommitTransaction(cancellationToken);

                    var viewModel = _mapper.Map<Nazm_tspagentEditForSendViewModel>(model);

                    return response
                        .WithSuccess(string.Format(Resources.Messages.Successes.Success, $"{Resources.Buttons.Save}"))
                        .WithValue(viewModel)
                        .ConvertToDtatResult();
                
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction(cancellationToken);
                throw;
            }

        }
    }
}
