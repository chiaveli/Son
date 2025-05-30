using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Son.Infra;

namespace Son;

public class Program
{
    public static async Task Main(string[] args)
    {
        string? url;

        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");    

        var sisConfig = new Sistema();
        builder.Configuration.Bind(sisConfig);
        builder.Services.AddSingleton(sisConfig);

        url = builder.Configuration["EnderecoApi"];

        Uri uri = new Uri(url!);

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = uri });
       //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(Sistema.EnderecoApi!) });

        builder.Services.AddBlazorBootstrap();
        await builder.Build().RunAsync();
    }
}
 