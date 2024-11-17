using Application.Common.Interfaces.Repository.Anemic.Oracle;
using Domain.Anemic.Entities;
using Persistence.Configurations.Anemic.Contexts;

namespace Infrastructure.Repository.Anemic.Oracle
{
    public class STATUS_COUNTRepository : EFOracleRepository<STATUS_COUNT>, ISTATUS_COUNTRepository
    {
        public STATUS_COUNTRepository(OracleContext context) : base(context)
        {
        }
    }
}
