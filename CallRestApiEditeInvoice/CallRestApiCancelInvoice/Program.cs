// See https://aka.ms/new-console-template for more information


using CallRestApiCancelInvoice;
using CallRestApiInvoice;
using System.Configuration;
using System.Net;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

HttpClient http = new HttpClient();


var Api = ConfigurationManager.AppSettings["Api"];

Invoices invoices = new Invoices();

invoices.Token = ConfigurationManager.AppSettings["Token"];
invoices.XOrgId = ConfigurationManager.AppSettings["XOrgId"];

try
{
	int row = 1;

	HttpResponseMessage response = null;

	var result = await http.PostAsJsonAsync(requestUri: $"{Api}/api/EditInvoices", invoices);

	while (result.StatusCode == HttpStatusCode.OK)
	{
		Result message = await result.Content.ReadFromJsonAsync<Result>();

		Console.WriteLine($"{row} _ {message.Value}");

		result = await http.PostAsJsonAsync(requestUri: $"{Api}/api/EditInvoices", invoices);
	}

}
catch (Exception)
{
	throw;
}

finally
{
	System.Environment.Exit(1);
}
