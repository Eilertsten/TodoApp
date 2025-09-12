using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoApp;
using TodoApp.Services; // <--- add this

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// existing HttpClient registration
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// register the in-memory Todo service so components can inject it
builder.Services.AddSingleton<TodoService>();

await builder.Build().RunAsync();





//using Microsoft.AspNetCore.Components.Web;
// using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
// using TodoApp;

// var builder = WebAssemblyHostBuilder.CreateDefault(args);
// builder.RootComponents.Add<App>("#app");
// builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// await builder.Build().RunAsync();
