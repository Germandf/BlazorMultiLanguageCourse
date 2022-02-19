using BlazorMultiLanguageCourse.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddLocalization();

var host = builder.Build();
var js = host.Services.GetRequiredService<IJSRuntime>();
var culture = await js.InvokeAsync<string>("culture.get");
if(culture is null)
{
    var defaultCulture = new CultureInfo("en-US");
    CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
    CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;
}
else
{
    var userCulture = new CultureInfo(culture);
    CultureInfo.DefaultThreadCurrentCulture = userCulture;
    CultureInfo.DefaultThreadCurrentUICulture = userCulture;
}

await builder.Build().RunAsync();
