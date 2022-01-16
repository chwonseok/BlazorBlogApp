using BlazorBlogApp.Client;
using BlazorBlogApp.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IBlogService, BlogService>(); // dependency injection이라 불림
    // AddScoped<BlogService를 inject하기 위해 IBlogService(여기선 interface), 앞의 것을 하기 위한 implementation class를 추가하기>
    // "BlogService(Implementation Class) registered for the IBlogService Interface.."

await builder.Build().RunAsync();
