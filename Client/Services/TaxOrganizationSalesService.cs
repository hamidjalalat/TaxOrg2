
namespace Client.Services
{
	public class TaxOrganizationSalesService : Infrastructure.ServiceBase
	{
        // ********************
        #region Properties

        private string strServiceUriOra = string.Empty;

        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly Client.Services.Tokens.ITokensService _tokenService;
        private readonly Infrastructure.NazmAuthenticationStateProvider _authStateProvider;

        // ********************
        #endregion

        public TaxOrganizationSalesService
            (
                System.Net.Http.HttpClient httpClient,
                LogsService logsService,
                Microsoft.Extensions.Configuration.IConfiguration configuration,
                Client.Services.Tokens.ITokensService tokenService,
                Infrastructure.NazmAuthenticationStateProvider authStateProvider
            ) : base(httpClient, logsService, configuration, tokenService, authStateProvider)
        {
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
            _tokenService = tokenService;

            strServiceUriOra = $"{Infrastructure.Utility.setServiceUriOra<TaxOrganizationSalesService>()}";
		}

		public async
			System.Threading.Tasks.Task
			<Nazm.Results.Result
			<ViewModels.PagingViewModel
			<ViewModels.TaxOrganizationSales.TaxOrganizationSaleViewModel>>>
			FetchAsync(ViewModels.Shared.PublicViewModel inputParamsViewModel)
		{
			string url = $"{strServiceUriOra}FetchAll";

			var result =
				await
				PostAsync
				<ViewModels.Shared.PublicViewModel,
				Nazm.Results.Result<ViewModels.PagingViewModel<ViewModels.TaxOrganizationSales.TaxOrganizationSaleViewModel>>>
				(url: url, viewModel: inputParamsViewModel);

			return result;
		}

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <ViewModels.PagingViewModel
            <ViewModels.TaxOrganizationSales.TaxOrganizationSaleForGridViewModel>>>
            FetchAllByFilterTaxOrganizationSaleAsync(ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputParamsViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUriOra}FetchAllByFilterTaxOrganizationSale";

            var result =
                await
                PostAsync
                <ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputParamsViewModel,
                Nazm.Results.Result<ViewModels.PagingViewModel<ViewModels.TaxOrganizationSales.TaxOrganizationSaleForGridViewModel>>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <byte[]>>
            FetchAllByFilterTaxOrganizationSaleAndFileDownloadAsync(ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputParamsViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUriOra}FetchAllByFilterTaxOrganizationSale";

            var result =
                await
                PostAsync
                <ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputParamsViewModel,
                Nazm.Results.Result<byte[]>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
           System.Threading.Tasks.Task
           <ViewModels.TaxOrganizationSales.TaxOrganizationSaleViewModel>
           FindByIdAsync(int Id)
        {
            string url = $"{strServiceUriOra}FindById";

            var result =
                await
                FindByIdAsync
                <Nazm.Results.Result
                <ViewModels.TaxOrganizationSales.TaxOrganizationSaleViewModel>>
                (url: url, Id);

            return result.Value;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <long>>
            GetCountInvoiceAsync(ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputDateInvoiceViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUriOra}GetCountInvoice";

            var result =
                await
                PostAsync
                <ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputDateInvoiceViewModel, Nazm.Results.Result<long>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <long>>
            GetCountInvoiceCancelAsync(ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputDateInvoiceViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUriOra}GetCountInvoiceCancel";

            var result =
                await
                PostAsync
                <ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputDateInvoiceViewModel, Nazm.Results.Result<long>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <long>>
            GetCountInvoicePendingAsync(ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputDateInvoiceViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUriOra}GetCountInvoicePending";

            var result =
                await
                PostAsync
                <ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputDateInvoiceViewModel, Nazm.Results.Result<long>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <long>>
            GetCountInvoiceSendingAsync(ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputDateInvoiceViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUriOra}GetCountInvoiceSending";

            var result =
                await
                PostAsync
                <ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputDateInvoiceViewModel, Nazm.Results.Result<long>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <long>>
            GetCountInvoiceSuccessAsync(ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputDateInvoiceViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUriOra}GetCountInvoiceSuccess";

            var result =
                await
                PostAsync
                <ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputDateInvoiceViewModel, Nazm.Results.Result<long>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <long>>
            GetCountInvoiceFailedAsync(ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputDateInvoiceViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUriOra}GetCountInvoiceFailed";

            var result =
                await
                PostAsync
                <ViewModels.TaxOrganizationSales.TaxOrganizationSaleInputDateInvoiceViewModel, Nazm.Results.Result<long>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
		  System.Threading.Tasks.Task
		  <Nazm.Results.Result
		  <ViewModels.TaxOrganizationSales.TaxOrganizationSaleViewModel>>
		  PostAsync(ViewModels.TaxOrganizationSales.TaxOrganizationSaleCreateViewModel viewModel)
		{
			try
			{
				string url = $"{strServiceUriOra}";

				var result =
					await
					PostAsync
					<ViewModels.TaxOrganizationSales.TaxOrganizationSaleCreateViewModel,
					Nazm.Results.Result<ViewModels.TaxOrganizationSales.TaxOrganizationSaleViewModel>>
					(url: url, viewModel);

				return result;
			}
			catch (System.Exception ex)
			{
				string str = ex.Message;
			}

			return default;
		}

		public async
		System.Threading.Tasks.Task
		<Nazm.Results.Result
		<ViewModels.TaxOrganizationSales.TaxOrganizationSaleUpdateViewModel>>
		PutAsync(ViewModels.TaxOrganizationSales.TaxOrganizationSaleUpdateViewModel viewModel)
		{
			try
			{
				string url = $"{strServiceUriOra}";

				var result =
					await
					PutAsync
					<ViewModels.TaxOrganizationSales.TaxOrganizationSaleUpdateViewModel,
					Nazm.Results.Result<ViewModels.TaxOrganizationSales.TaxOrganizationSaleUpdateViewModel>>
					(url: url, viewModel);

				return result;
			}
			catch (System.Exception ex)
			{
				string str = ex.Message;
			}

			return default;
		}

		public async
		  System.Threading.Tasks.Task
			<Nazm.Results.Result>
		  DeleteAsync(int Id)
		{
			string url = $"{strServiceUriOra}";

			var result =
				await
				DeleteAsync<Nazm.Results.Result>
				(url: url, Id);

			return result;

		}

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <bool>>
            CancelByIdAsync(ViewModels.TaxOrganizationSales.TaxOrganizationSaleCancelInputParamsViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUriOra}CancelById";

            var result =
                await
                PostAsync
                <ViewModels.TaxOrganizationSales.TaxOrganizationSaleCancelInputParamsViewModel,
                Nazm.Results.Result<bool>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task

        <Nazm.Results.Result
        <bool>>
            EditForSendAsync(ViewModels.TaxOrganizationSales.TaxOrganizationSaleEditForSendInputParamsViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUriOra}EditForSend";

            var result =
                await
                PostAsync
                <ViewModels.TaxOrganizationSales.TaxOrganizationSaleEditForSendInputParamsViewModel, 
                Nazm.Results.Result<bool>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }
    }
}
