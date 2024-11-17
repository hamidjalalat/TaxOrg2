using Application.Common.Interfaces.Repository.Anemic.Base;
using AutoMapper;
using Dapper.Oracle;
using Application.Features.Anemic;
using MediatR;
using Nazm.Results;
using System.Data;
using Application.Features.Anemic.TaxOrganizationSales.Commands;
using Application.Common.Extensions;

namespace Application.Features.Anemic.TaxOrganizationSales.Commands
{
    public class TaxOrganizationSaleCancelDapperCommand : BaseRequest, IRequest<Result<bool>>
    {
        public TaxOrganizationSaleCancelDapperCommand()
        {

        }
        public TaxOrganizationSaleCancelDapperCommand(int id)
        {
            TaxOrganizationSaleId = id;
        }
        public int TaxOrganizationSaleId { get; set; }
    }
}

public class TaxOrganizationSaleCancelDapperCommandHandler : BaseRequestHandler<TaxOrganizationSaleCancelDapperCommand, Result<bool>>
{

    public TaxOrganizationSaleCancelDapperCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
    {
    }

    protected async override Task<Result<bool>> HandleRequestAsync(TaxOrganizationSaleCancelDapperCommand input, CancellationToken cancellationToken)
    {
        var response = new FluentResults.Result<bool>();
        List<string> errorList = new List<string>();
        bool result = false;

        try
        {
            var dyParam = new OracleDynamicParameters();
            dyParam.Add(":P_ID", input.TaxOrganizationSaleId, OracleMappingType.Int64, ParameterDirection.Input);
            //dyParam.Add(":NEWDATE", System.DateTime.Now.Date., OracleMappingType.NVarchar2, ParameterDirection.Input);
            dyParam.Add(":NEWDATESH", Convert.ToInt32(System.DateTime.Now.Date.ToPersianDate().Replace("/", "")), OracleMappingType.Int32, ParameterDirection.Input);

            await _unitOfWork.ProductDapper.Exeute(
                                                    dyParam,
                                                    "PROC_TAX_ORGANIZATION_SALES_CANCEL",
                                                    Domain.Enums.DatabaseTypeEnum.Oracle
                                                  );

            result = true;

        }
        catch (Exception ex)
        {
            errorList.Add(string.Format(Resources.Messages.Errors.Error, $"{Resources.DataDictionary.Cancel}"));
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
