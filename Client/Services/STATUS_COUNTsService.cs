
namespace Client.Services
{
	public class STATUS_COUNTsService : Infrastructure.ServiceBase
	{
        // ********************
        #region Properties

        private string strServiceUri = string.Empty;

        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly Client.Services.Tokens.ITokensService _tokenService;
        private readonly Infrastructure.NazmAuthenticationStateProvider _authStateProvider;

        // ********************
        #endregion

        public STATUS_COUNTsService
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

            strServiceUri = $"{Infrastructure.Utility.setServiceUri<STATUS_COUNTsService>()}";
		}

		public async
			System.Threading.Tasks.Task
			<Nazm.Results.Result
			<ViewModels.PagingViewModel
			<ViewModels.STATUS_COUNTs.STATUS_COUNTViewModel>>>
            FetchtByYEARAsync(ViewModels.STATUS_COUNTs.STATUS_COUNTInputParamsViewModel inputParamsViewModel)
		{
			string url = $"{strServiceUri}FetchtByYEAR";

			var result =
				await
				PostAsync
				<ViewModels.STATUS_COUNTs.STATUS_COUNTInputParamsViewModel,
				Nazm.Results.Result<ViewModels.PagingViewModel<ViewModels.STATUS_COUNTs.STATUS_COUNTViewModel>>>
				(url: url, viewModel: inputParamsViewModel);

			return result;
		}



	}
}
