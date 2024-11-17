using Application.Common.Interfaces.Repository.Anemic.Base;
using Domain.Anemic.Entities;
using FluentResults;

namespace Application.Common.Interfaces.Repository.Anemic.Oracle
{
    public interface ISERVICE_TYPERepository : IRepository<SERVICE_TYPE>
    {
        Task<Result<bool>> IsUnique(SERVICE_TYPE model,CancellationToken cancellationToken);
        SERVICE_TYPE DeleteSERVICE_TYPE(SERVICE_TYPE Entity);

        SERVICE_TYPE UpdateSERVICE_TYPE(SERVICE_TYPE Entity);

        SERVICE_TYPE InsertSERVICE_TYPE(SERVICE_TYPE Entity);
    }
}
