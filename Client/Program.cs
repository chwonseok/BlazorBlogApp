using BlazorBlogApp.Client;
using BlazorBlogApp.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IBlogService, BlogService>(); // dependency injection�̶� �Ҹ�
    // AddScoped<BlogService�� inject�ϱ� ���� IBlogService(���⼱ interface), ���� ���� �ϱ� ���� implementation class�� �߰��ϱ�>
    // "BlogService(Implementation Class) registered for the IBlogService Interface.."

await builder.Build().RunAsync();
