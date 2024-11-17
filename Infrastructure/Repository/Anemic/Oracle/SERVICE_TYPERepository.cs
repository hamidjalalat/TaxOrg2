using Application.Common.Interfaces.Repository.Anemic.Oracle;
using Domain.Anemic.Entities;
using Persistence.Configurations.Anemic.Contexts;
using Microsoft.EntityFrameworkCore;
using FluentResults;

namespace Infrastructure.Repository.Anemic.Oracle
{
    public class SERVICE_TYPERepository : EFOracleRepository<SERVICE_TYPE>, ISERVICE_TYPERepository
    {
        public SERVICE_TYPERepository(OracleContext context) : base(context)
        {
            _oracleContext = context;
        }
        private readonly OracleContext _oracleContext;

        public async Task<Result<bool>> IsUnique(SERVICE_TYPE model, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<bool>();
            List<String> errorList = new List<String>();

            #region Add
            if (model.ID == 0)
            {
                var isExist = await GetAll.AnyAsync(s => s.SSTID == model.SSTID, cancellationToken);
                if (isExist)
                {
                    errorList.Add(string.Format(Resources.Messages.Validations.Repetitive, Resources.DataDictionary.SSTID));
                }
            }
            #endregion

            #region Edit
            if (model.ID > 0)
            {
                var isExist = await GetAll.AnyAsync(s => s.ID != model.ID && s.SSTID == model.SSTID, cancellationToken);
                if (isExist)
                {
                    errorList.Add(string.Format(Resources.Messages.Validations.Repetitive, Resources.DataDictionary.SSTID));
                }
            }
            #endregion

            if (errorList.Count > 0)
            {
                return result.WithErrors(errorList);
            }
            else
            {
                return result.WithValue(true);
            }
        }

        public SERVICE_TYPE DeleteSERVICE_TYPE(SERVICE_TYPE Entity)
        {
            _oracleContext.Remove(Entity);
            _oracleContext.SaveChanges();

            return Entity;
        }
        public SERVICE_TYPE UpdateSERVICE_TYPE(SERVICE_TYPE Entity)
        {
            _oracleContext.Update(Entity);
            _oracleContext.SaveChanges();

            return Entity;
        }

        public SERVICE_TYPE InsertSERVICE_TYPE(SERVICE_TYPE Entity)
        {
            _oracleContext.Add(Entity);
            _oracleContext.SaveChanges();

            return Entity;
        }

    }
}
