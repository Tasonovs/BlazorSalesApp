using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorSalesApp.Ui;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseAddress = builder.Configuration.GetValue<string>("BaseUrl")!;
builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri(baseAddress)
});
builder.Services.AddMudServices();

await builder.Build().RunAsync();