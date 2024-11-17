﻿using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.EF;
using AutoMapper;
using Domain.Anemic.Entities;
using MediatR;
using Nazm.Results;
using NazmMapping.Mappings;
using ViewModels.Nazm_tspagents;

namespace Application.Features.Anemic.Nazm_tspagents.Commands
{
    public class Nazm_tspagentCancelCommand : BaseRequest, IRequest<Result<bool>>, IMapFrom<Nazm_tspagent>
    {
        public Nazm_tspagentCancelCommand()
        {

        }
        public Nazm_tspagentCancelCommand(int id)
        {
            Nazm_tspagentId = id;
        }
        public int Nazm_tspagentId { get; set; }
    }

    public class Nazm_tspagentCancelCommandHandler : BaseRequestHandler<Nazm_tspagentCancelCommand, Result<bool>>
    {
        private readonly INazm_tspagentRepository _Nazm_tspagentRepository;

        public Nazm_tspagentCancelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, INazm_tspagentRepository Nazm_tspagentRepository) : base(unitOfWork, mapper)
        {
            _Nazm_tspagentRepository = Nazm_tspagentRepository;
        }

        protected override async Task<Result<bool>> HandleRequestAsync(Nazm_tspagentCancelCommand input, CancellationToken cancellationToken)
        {
            bool result = false;

            var response = new FluentResults.Result<bool>();

            try
            {
                await _unitOfWork.BeginTransaction(cancellationToken);

                var model = await _unitOfWork.Nazm_tspagents.FindByIdAsync(input.Nazm_tspagentId,cancellationToken);

                if (model != null)
                {

                    model.ins = 3;
                    model.inno = model.inno * 100;
                    model.indatim = DateTime.Now.Date;
                    model.Status = "";
                    //model.DATM = Convert.ToInt32(DateTime.Now.Date.ToPersianDate().Replace("/", ""));
                    //model.NEWDATA = Convert.ToInt32(DateTime.Now.Date.ToPersianDate().Replace("/", ""));
                    model.irtaxid = model.TaxId;
                    model.TaxId = "";
                    model.Reference_Id = "";

                    _unitOfWork.Nazm_tspagents.Update(model);
                }

                response.WithSuccess(string.Format(Resources.Messages.Successes.Success, $"{Resources.DataDictionary.Cancel}"));

                await _unitOfWork.Commit(cancellationToken);
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
