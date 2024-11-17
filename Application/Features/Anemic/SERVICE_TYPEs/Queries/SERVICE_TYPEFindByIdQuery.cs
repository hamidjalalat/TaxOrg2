using Application.Common.Interfaces.Repository.Anemic.Base;
using Application.Common.Interfaces.Repository.Anemic.EF;
using Application.Common.Interfaces.Repository.Anemic.Oracle;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nazm.Results;
using NazmMapping.Mappings;
using ViewModels.SERVICE_TYPEs;

namespace Application.Features.Anemic.SERVICE_TYPEs.Queries
{
    public class SERVICE_TYPEFindByIdQuery : BaseRequest, IRequest<Result<SERVICE_TYPEViewModel>>
    {
        public SERVICE_TYPEFindByIdQuery()
        {

        }
        public SERVICE_TYPEFindByIdQuery(int id)
        {

            ID = id;
        }
        public int ID { get; set; }

    }

    public class SERVICE_TYPEGetByIdQueryHandler : BaseRequestHandler<SERVICE_TYPEFindByIdQuery, Result<SERVICE_TYPEViewModel>>
    {
        private readonly ISERVICE_TYPERepository _SERVICE_TYPERepository;


        public SERVICE_TYPEGetByIdQueryHandler(ISERVICE_TYPERepository SERVICE_TYPERepository, IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            _SERVICE_TYPERepository = SERVICE_TYPERepository;
        }

        protected async override Task<Result<SERVICE_TYPEViewModel>> HandleRequestAsync(SERVICE_TYPEFindByIdQuery input, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<SERVICE_TYPEViewModel>();

            var response = await _unitOfWork.SERVICE_TYPEs.FindByIdAsync(input.ID, cancellationToken);

            var SERVICE_TYPEViewModel = _mapper.Map<SERVICE_TYPEViewModel>(response);

            return result.WithValue(SERVICE_TYPEViewModel).ConvertToDtatResult();
        }
    }
}
