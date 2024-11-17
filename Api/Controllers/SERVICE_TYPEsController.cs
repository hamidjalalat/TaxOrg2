using Application.Features.Anemic.FileOperations.Queries;
using Application.Features.Anemic.SERVICE_TYPEs.Queries;
using Application.Features.Anemic.SERVICE_TYPEs.Commands;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Shared;
using ViewModels.SERVICE_TYPEs;
using Application.Features.Anemic.TaxOrganizationSales.Queries;

namespace Api.Controllers
{
    public class SERVICE_TYPEsController : ApiControllerBase
    {

        [HttpPost("FetchAll")]
        public async Task<IActionResult> FetchAll(PublicViewModel inputParamsViewModel, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new SERVICE_TYPEGetAllQuery(inputParamsViewModel), cancellationToken);

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

        [HttpPost]
        public async Task<IActionResult> Post(SERVICE_TYPECreateViewModel viewModel, CancellationToken cancellationToken)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(new SERVICE_TYPECreateCommand { SERVICE_TYPEViewModel = viewModel }, cancellationToken);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SERVICE_TYPEUpdateViewModel viewModel, CancellationToken cancellationToken)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }

            if (viewModel.ID < 1)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(new SERVICE_TYPEUpdateCommand { SERVICE_TYPEViewModel = viewModel }, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(new SERVICE_TYPEDeleteCommand(id), cancellationToken);

            return Ok(result);
        }

        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(int id, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new SERVICE_TYPEFindByIdQuery(id), cancellationToken);

            return Ok(result);
        }

    }
}
