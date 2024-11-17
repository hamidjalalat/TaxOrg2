// See https://aka.ms/new-console-template for more information


using CallRestApiInquiry;
using CallRestApiInvoice;
using System.Configuration;
using System.Net;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

HttpClient http=new HttpClient();


Console.WriteLine("Start");

try
{
	int row = 1;

	var Api = ConfigurationManager.AppSettings["Api"];

	RequestInquiry requestInquiry = new RequestInquiry();

	requestInquiry.Token = ConfigurationManager.AppSettings["Token"];
	requestInquiry.XOrgId = ConfigurationManager.AppSettings["XOrgId"];

	var result = await http.PostAsJsonAsync(requestUri: $"{Api}/api/Inquires", requestInquiry);

	while (result.StatusCode == HttpStatusCode.OK)
	{
		Result message = await result.Content.ReadFromJsonAsync<Result>();

		Console.WriteLine($"{row} _ {message.Value}");

		row++;

		result = await http.PostAsJsonAsync(requestUri: $"{Api}/api/Inquires", requestInquiry);
	}

	if (result.StatusCode != HttpStatusCode.OK)
		Console.Write("result:" + result.StatusCode);
}

catch (Exception)
{
	throw;
}

finally
{
	System.Environment.Exit(1);
}


