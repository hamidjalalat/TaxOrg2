
namespace Client.Services
{
	public class InvoiceModelsService : Infrastructure.ServiceBase
	{
        // ********************
        #region Properties

        private string strServiceUri = string.Empty;

        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly Client.Services.Tokens.ITokensService _tokenService;
        private readonly Infrastructure.NazmAuthenticationStateProvider _authStateProvider;

        // ********************
        #endregion

        public InvoiceModelsService
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

            strServiceUri = $"{Infrastructure.Utility.setServiceUri<InvoiceModelsService>()}";
		}

        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <ViewModels.PagingViewModel
            <ViewModels.InvoiceModels.InvoiceModelActiveViewModel>>>
			FetchActiveAsync(ViewModels.Shared.PublicViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}FetchActive";

            var result =
                await
                PostAsync
                <ViewModels.Shared.PublicViewModel,
                Nazm.Results.Result<ViewModels.PagingViewModel<ViewModels.InvoiceModels.InvoiceModelActiveViewModel>>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }


	}
}
