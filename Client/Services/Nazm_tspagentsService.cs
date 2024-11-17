
namespace Client.Services
{
	public class Nazm_tspagentsService : Infrastructure.ServiceBase
	{
        // ********************
        #region Properties

        private string strServiceUri = string.Empty;

        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly Client.Services.Tokens.ITokensService _tokenService;
        private readonly Infrastructure.NazmAuthenticationStateProvider _authStateProvider;

        // ********************
        #endregion

        public Nazm_tspagentsService
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

            strServiceUri = $"{Infrastructure.Utility.setServiceUri<Nazm_tspagentsService>()}";
		}

		public async
			System.Threading.Tasks.Task
			<Nazm.Results.Result
			<ViewModels.PagingViewModel
			<ViewModels.Nazm_tspagents.Nazm_tspagentViewModel>>>
			FetchAsync(ViewModels.Shared.PublicViewModel inputParamsViewModel)
		{
			string url = $"{strServiceUri}FetchAll";

			var result =
				await
				PostAsync
				<ViewModels.Shared.PublicViewModel,
				Nazm.Results.Result<ViewModels.PagingViewModel<ViewModels.Nazm_tspagents.Nazm_tspagentViewModel>>>
				(url: url, viewModel: inputParamsViewModel);

			return result;
		}

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <ViewModels.PagingViewModel
            <ViewModels.Nazm_tspagents.Nazm_tspagentViewModel>>>
            FetchAllByFilterNazm_tspagentAsync(ViewModels.Nazm_tspagents.Nazm_tspagentInputParamsViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}FetchAllByFilterNazm_tspagent";

            var result =
                await
                PostAsync
                <ViewModels.Nazm_tspagents.Nazm_tspagentInputParamsViewModel,
                Nazm.Results.Result<ViewModels.PagingViewModel<ViewModels.Nazm_tspagents.Nazm_tspagentViewModel>>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <byte[]>>
            FetchAllByFilterNazm_tspagentAndFileDownloadAsync(ViewModels.Nazm_tspagents.Nazm_tspagentInputParamsViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}FetchAllByFilterNazm_tspagent";

            var result =
                await
                PostAsync
                <ViewModels.Nazm_tspagents.Nazm_tspagentInputParamsViewModel,
                Nazm.Results.Result<byte[]>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
           System.Threading.Tasks.Task
           <ViewModels.Nazm_tspagents.Nazm_tspagentViewModel>
           FindByIdAsync(int Id)
        {
            string url = $"{strServiceUri}FindById";

            var result =
                await
                FindByIdAsync
                <Nazm.Results.Result
                <ViewModels.Nazm_tspagents.Nazm_tspagentViewModel>>
                (url: url, Id);

            return result.Value;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <long>>
            GetCountInvoiceAsync(ViewModels.Nazm_tspagents.Nazm_tspagentInputDateInvoiceViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}GetCountInvoice";

            var result =
                await
                PostAsync
                <ViewModels.Nazm_tspagents.Nazm_tspagentInputDateInvoiceViewModel, Nazm.Results.Result<long>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <long>>
            GetCountInvoiceCancelAsync(ViewModels.Nazm_tspagents.Nazm_tspagentInputDateInvoiceViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}GetCountInvoiceCancel";

            var result =
                await
                PostAsync
                <ViewModels.Nazm_tspagents.Nazm_tspagentInputDateInvoiceViewModel, Nazm.Results.Result<long>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <long>>
            GetCountInvoicePendingAsync(ViewModels.Nazm_tspagents.Nazm_tspagentInputDateInvoiceViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}GetCountInvoicePending";

            var result =
                await
                PostAsync
                <ViewModels.Nazm_tspagents.Nazm_tspagentInputDateInvoiceViewModel, Nazm.Results.Result<long>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <long>>
            GetCountInvoiceSendingAsync(ViewModels.Nazm_tspagents.Nazm_tspagentInputDateInvoiceViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}GetCountInvoiceSending";

            var result =
                await
                PostAsync
                <ViewModels.Nazm_tspagents.Nazm_tspagentInputDateInvoiceViewModel, Nazm.Results.Result<long>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <long>>
            GetCountInvoiceSuccessAsync(ViewModels.Nazm_tspagents.Nazm_tspagentInputDateInvoiceViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}GetCountInvoiceSuccess";

            var result =
                await
                PostAsync
                <ViewModels.Nazm_tspagents.Nazm_tspagentInputDateInvoiceViewModel, Nazm.Results.Result<long>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <long>>
            GetCountInvoiceFailedAsync(ViewModels.Nazm_tspagents.Nazm_tspagentInputDateInvoiceViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}GetCountInvoiceFailed";

            var result =
                await
                PostAsync
                <ViewModels.Nazm_tspagents.Nazm_tspagentInputDateInvoiceViewModel, Nazm.Results.Result<long>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
		  System.Threading.Tasks.Task
		  <Nazm.Results.Result
		  <ViewModels.Nazm_tspagents.Nazm_tspagentViewModel>>
		  PostAsync(ViewModels.Nazm_tspagents.Nazm_tspagentCreateViewModel viewModel)
		{
			try
			{
				string url = $"{strServiceUri}";

				var result =
					await
					PostAsync
					<ViewModels.Nazm_tspagents.Nazm_tspagentCreateViewModel,
					Nazm.Results.Result<ViewModels.Nazm_tspagents.Nazm_tspagentViewModel>>
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
		<ViewModels.Nazm_tspagents.Nazm_tspagentViewModel>>
		PutAsync(ViewModels.Nazm_tspagents.Nazm_tspagentUpdateViewModel viewModel)
		{
			try
			{
				string url = $"{strServiceUri}";

				var result =
					await
					PutAsync
					<ViewModels.Nazm_tspagents.Nazm_tspagentUpdateViewModel,
					Nazm.Results.Result<ViewModels.Nazm_tspagents.Nazm_tspagentViewModel>>
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
			string url = $"{strServiceUri}";

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
            CancelByIdAsync(ViewModels.Nazm_tspagents.Nazm_tspagentCancelViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}CancelById";

            var result =
                await
                PostAsync
                <ViewModels.Nazm_tspagents.Nazm_tspagentCancelViewModel,
                Nazm.Results.Result<bool>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

        public async
            System.Threading.Tasks.Task

        <Nazm.Results.Result
        <ViewModels.Nazm_tspagents.Nazm_tspagentViewModel>>
            EditForSendAsync(ViewModels.Nazm_tspagents.Nazm_tspagentEditForSendViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}EditForSend";

            var result =
                await
                PostAsync
                <ViewModels.Nazm_tspagents.Nazm_tspagentEditForSendViewModel, 
                Nazm.Results.Result<ViewModels.Nazm_tspagents.Nazm_tspagentViewModel>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }
    }
}
