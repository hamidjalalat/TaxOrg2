// See https://aka.ms/new-console-template for more information


using CallRestApiInquiry;
using CallRestApiInvoice;
using System.Configuration;
using System.Net;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

HttpClient http=new HttpClient();

try
{
	var Api = ConfigurationManager.AppSettings["Api"];

	HttpResponseMessage response = null;

	Invoices invoices = new Invoices();

	invoices.Token = ConfigurationManager.AppSettings["Token"];
	invoices.XOrgId = ConfigurationManager.AppSettings["XOrgId"];

	var result = await http.PostAsJsonAsync(requestUri: $"{Api}/api/Invoices", invoices);

	while (result.StatusCode == HttpStatusCode.OK)
	{
		Result message = await result.Content.ReadFromJsonAsync<Result>();

		Console.Write($"{message.Value}");

		result = await http.PostAsJsonAsync(requestUri: $"{Api}/api/Invoices", invoices);
	}
}
catch (Exception)
{
	System.Environment.Exit(1);
}


Console.WriteLine("Finished");
