﻿
namespace Client.Services
{
	public class SERVICE_TYPEsService : Infrastructure.ServiceBase
	{
        // ********************
        #region Properties

        private string strServiceUri = string.Empty;

        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly Client.Services.Tokens.ITokensService _tokenService;
        private readonly Infrastructure.NazmAuthenticationStateProvider _authStateProvider;

        // ********************
        #endregion

        public SERVICE_TYPEsService
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

            strServiceUri = $"{Infrastructure.Utility.setServiceUri<SERVICE_TYPEsService>()}";
		}


        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <ViewModels.PagingViewModel
            <ViewModels.SERVICE_TYPEs.SERVICE_TYPEViewModel>>>
            FetchAsync(ViewModels.Shared.PublicViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}FetchAll";

            var result =
                await
                PostAsync
                <ViewModels.Shared.PublicViewModel,
                Nazm.Results.Result<ViewModels.PagingViewModel<ViewModels.SERVICE_TYPEs.SERVICE_TYPEViewModel>>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }


        public async
            System.Threading.Tasks.Task
            <Nazm.Results.Result
            <byte[]>>
            FetchAllAndFileDownloadAsync(ViewModels.Shared.PublicViewModel inputParamsViewModel)
        {
            string url = $"{strServiceUri}FetchAll";

            var result =
                await
                PostAsync
                <ViewModels.Shared.PublicViewModel,
                Nazm.Results.Result<byte[]>>
                (url: url, viewModel: inputParamsViewModel);

            return result;
        }

		public async
		   System.Threading.Tasks.Task
		   <ViewModels.SERVICE_TYPEs.SERVICE_TYPEViewModel>
		   FindByIdAsync(int Id)
		{
			string url = $"{strServiceUri}FindById";

			var result =
				await
				FindByIdAsync
				<Nazm.Results.Result
				<ViewModels.SERVICE_TYPEs.SERVICE_TYPEViewModel>>
				(url: url, Id);

			return result.Value;
		}


		public async
              System.Threading.Tasks.Task
              <Nazm.Results.Result
              <ViewModels.SERVICE_TYPEs.SERVICE_TYPEViewModel>>
              PostAsync(ViewModels.SERVICE_TYPEs.SERVICE_TYPECreateViewModel viewModel)
        {
            try
            {
                string url = $"{strServiceUri}";

                var result =
                    await
                    PostAsync
                    <ViewModels.SERVICE_TYPEs.SERVICE_TYPECreateViewModel,
                    Nazm.Results.Result<ViewModels.SERVICE_TYPEs.SERVICE_TYPEViewModel>>
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
            <ViewModels.SERVICE_TYPEs.SERVICE_TYPEViewModel>>
            PutAsync(ViewModels.SERVICE_TYPEs.SERVICE_TYPEUpdateViewModel viewModel)
        {
            try
            {
                string url = $"{strServiceUri}";

                var result =
                    await
                    PutAsync
                    <ViewModels.SERVICE_TYPEs.SERVICE_TYPEUpdateViewModel,
                    Nazm.Results.Result<ViewModels.SERVICE_TYPEs.SERVICE_TYPEViewModel>>
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
    }
}
