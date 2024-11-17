using Microsoft.AspNetCore.Mvc;
using ViewModels.TaxOrganizationSales;
using ViewModels.Shared;
using Application.Features.Anemic.TaxOrganizationSales.Queries;
using Application.Features.Anemic.FileOperations.Queries;
using Application.Features.Anemic.TaxOrganizationSales.Commands;

namespace Api.Controllers
{
    [Route("api/ora/[controller]")]
    [ApiController]
    public class TaxOrganizationSalesController : ApiControllerBase
    {



        //[HttpPost("FetchAll")]
        //public async Task<IActionResult> Get(PublicViewModel inputParamsViewModel, CancellationToken cancellationToken)
        //{
        //    var result = await Mediator.Send(new TaxOrganizationSaleGetQuery(inputParamsViewModel));
        //    return Ok(result);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteById(int id, CancellationToken cancellationToken)
        //{
        //    if (id < 1)
        //    {
        //        return BadRequest();
        //    }

        //    var result = await Mediator.Send(new TaxOrganizationSaleDeleteCommand(id), cancellationToken);

        //    return Ok(result);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Put([FromBody] TaxOrganizationSaleUpdateViewModel viewModel, CancellationToken cancellationToken)
        //{
        //    if (viewModel == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (viewModel.id < 1)
        //    {
        //        return BadRequest();
        //    }

        //    var result = await Mediator.Send(new TaxOrganizationSaleUpdateCommand { TaxOrganizationSaleViewModel = viewModel }, cancellationToken);

        //    return Ok(result);
        //}


        [HttpPost("FetchAll")]
        public async Task<IActionResult> FetchAll(PublicViewModel inputParamsViewModel, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new TaxOrganizationSaleGetAllQuery(inputParamsViewModel), cancellationToken);

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

        [HttpPost("FetchAllByFilterTaxOrganizationSale")]
        public async Task<IActionResult> FetchAllByFilterTaxOrganizationSale(TaxOrganizationSaleInputParamsViewModel inputParamsViewModel, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new TaxOrganizationSaleGetAllByFilterQuery(inputParamsViewModel), cancellationToken);

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

        [HttpPost("GetCountInvoice")]
        public async Task<IActionResult> GetCountInvoice([FromBody] TaxOrganizationSaleInputDateInvoiceViewModel inputParamsViewModel, CancellationToken cancellationToken)
        {
            var CountInvoice = await Mediator.Send(new TaxOrganizationSaleGetCountInvoiceQuery(inputParamsViewModel), cancellationToken);

            return Ok(CountInvoice);
        }

        [HttpPost("GetCountInvoiceCancel")]
        public async Task<IActionResult> GetCountInvoiceCancel([FromBody] TaxOrganizationSaleInputDateInvoiceViewModel inputParamsViewModel, CancellationToken cancellationToken)
        {
            var CountInvoiceCancel = await Mediator.Send(new TaxOrganizationSaleGetCountInvoiceCancelQuery(inputParamsViewModel), cancellationToken);

            return Ok(CountInvoiceCancel);
        }

        [HttpPost("GetCountInvoicePending")]
        public async Task<IActionResult> GetCountInvoicePending([FromBody] TaxOrganizationSaleInputDateInvoiceViewModel inputParamsViewModel, CancellationToken cancellationToken)
        {
            var CountInvoicePending = await Mediator.Send(new TaxOrganizationSaleGetCountInvoicePendingQuery(inputParamsViewModel), cancellationToken);

            return Ok(CountInvoicePending);
        }

        [HttpPost("GetCountInvoiceSending")]
        public async Task<IActionResult> GetGetCountInvoiceSending([FromBody] TaxOrganizationSaleInputDateInvoiceViewModel inputParamsViewModel, CancellationToken cancellationToken)
        {
            var CountInvoiceSending = await Mediator.Send(new TaxOrganizationSaleGetCountInvoiceSendingQuery(inputParamsViewModel), cancellationToken);

            return Ok(CountInvoiceSending);
        }

        [HttpPost("GetCountInvoiceSuccess")]
        public async Task<IActionResult> GetCountInvoiceSuccess([FromBody] TaxOrganizationSaleInputDateInvoiceViewModel inputParamsViewModel, CancellationToken cancellationToken)
        {
            var CountInvoiceSuccess = await Mediator.Send(new TaxOrganizationSaleGetCountInvoiceSuccessQuery(inputParamsViewModel), cancellationToken);

            return Ok(CountInvoiceSuccess);
        }

        [HttpPost("GetCountInvoiceFailed")]
        public async Task<IActionResult> GetCountInvoiceFailed([FromBody] TaxOrganizationSaleInputDateInvoiceViewModel inputParamsViewModel, CancellationToken cancellationToken)
        {
            var CountInvoiceFailed = await Mediator.Send(new TaxOrganizationSaleGetCountInvoiceFailedQuery(inputParamsViewModel), cancellationToken);

            return Ok(CountInvoiceFailed);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TaxOrganizationSaleCreateViewModel viewModel, CancellationToken cancellationToken)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(new TaxOrganizationSaleCreateCommand { TaxOrganizationSaleViewModel = viewModel }, cancellationToken);

            return Ok(result);
        }

        [HttpPost("EditForSend")]
        public async Task<IActionResult> EditForSend(TaxOrganizationSaleEditForSendInputParamsViewModel viewModel, CancellationToken cancellationToken)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(new TaxOrganizationSaleEditForSendCommand { InputViewModel = viewModel }, cancellationToken);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TaxOrganizationSaleUpdateViewModel viewModel, CancellationToken cancellationToken)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }

            if (viewModel.ID < 1)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(new TaxOrganizationSaleUpdateCommand { TaxOrganizationSaleViewModel = viewModel }, cancellationToken);

            return Ok(result);
        }


        [HttpPost("CancelById")]
        public async Task<IActionResult> CancelById(TaxOrganizationSaleCancelInputParamsViewModel viewModel, CancellationToken cancellationToken)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }

            if (viewModel.Id < 1)
            {
                return BadRequest();
            }

            //var result = await Mediator.Send(new TaxOrganizationSaleCancelDapperCommand(viewModel.Id), cancellationToken);
            var result = await Mediator.Send(new TaxOrganizationSaleCancelCommand(viewModel.Id), cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(new TaxOrganizationSaleDeleteCommand(id), cancellationToken);

            return Ok(result);
        }

        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(int id, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new TaxOrganizationSaleFindByIdQuery(id), cancellationToken);

            return Ok(result);
        }
    }
}
