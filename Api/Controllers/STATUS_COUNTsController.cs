using Application.Features.Anemic.FileOperations.Queries;
using Application.Features.Anemic.STATUS_COUNTs.Queries;
using Application.Features.Anemic.TaxOrganizationSales.Queries;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Shared;
using ViewModels.STATUS_COUNTs;

namespace Api.Controllers
{
    public class STATUS_COUNTsController : ApiControllerBase
    {

        [HttpPost("FetchtByYEAR")]
        public async Task<IActionResult> FetchAll(STATUS_COUNTInputParamsViewModel inputParamsViewModel, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new STATUS_COUNTGetByYEARQuery(inputParamsViewModel), cancellationToken);

            if (result.IsSuccess && inputParamsViewModel.FileExportType != null)
            {
                if (inputParamsViewModel.FileExportType == Domain.Enums.FileExportTypeEnum.Office_Excel)
                {
                    var resultExcelExport = await Mediator.Send(new FileDownloadExcelExportQuery(result.Value.Items, inputParamsViewModel.FileExportColumns), cancellationToken);

                    return Ok(resultExcelExport);
                }
            }

            return Ok(result);
        }
    }
}
