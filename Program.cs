using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;
using TodoApp;
using TodoApp.Services;
using TodoApp.Models;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Load appsettings.json
var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
var config = await http.GetFromJsonAsync<Dictionary<string, SupabaseConfig>>("appsettings.json");
if (config == null || !config.ContainsKey("Supabase"))
{
    throw new InvalidOperationException("Supabase configuration not found in appsettings.json.");
}
var supabase = config["Supabase"];

//Register HttpClient with Supabase base URL + headers
builder.Services.AddScoped(sp =>
{
    var client = new HttpClient { BaseAddress = new Uri(supabase.Url) };
    client.DefaultRequestHeaders.Add("apikey", supabase.AnonKey);
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {supabase.AnonKey}");
    return client;
});



// Register our service
builder.Services.AddScoped<SupabaseTodoService>();
builder.Services.AddScoped<TodoService>();


await builder.Build().RunAsync();





// // using Microsoft.AspNetCore.Components.Web;
// // using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
// // using TodoApp;
// // using TodoApp.Services; // <--- add this

// // var builder = WebAssemblyHostBuilder.CreateDefault(args);
// // builder.RootComponents.Add<App>("#app");
// // builder.RootComponents.Add<HeadOutlet>("head::after");

// // // existing HttpClient registration
// // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// // // register the in-memory Todo service so components can inject it
// // builder.Services.AddSingleton<TodoService>();

// // await builder.Build().RunAsync();

// using Microsoft.AspNetCore.Components.Web;
// using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
// using TodoApp;
// using TodoApp.Services;
// using System.Net.Http.Json;

// var builder = WebAssemblyHostBuilder.CreateDefault(args);
// builder.RootComponents.Add<App>("#app");
// builder.RootComponents.Add<HeadOutlet>("head::after");

// // Load config from wwwroot/appsettings.json
// var response = await new HttpClient().GetFromJsonAsync<Dictionary<string, Dictionary<string, string>>>(
//     new Uri(builder.HostEnvironment.BaseAddress + "appsettings.json")
// );

// if (response == null || !response.ContainsKey("Supabase"))
// {
//     throw new InvalidOperationException("Supabase configuration not found in appsettings.json.");
// }

// var supabaseConfig = response["Supabase"];
// var supabaseUrl = supabaseConfig["Url"];
// var supabaseKey = supabaseConfig["AnonKey"];

// // Register HttpClient with Supabase base URL
// builder.Services.AddScoped(sp => new HttpClient
// {
//     BaseAddress = new Uri(supabaseUrl),
//     DefaultRequestHeaders = { { "apikey", supabaseKey }, { "Authorization", $"Bearer {supabaseKey}" } }
// });

// // Register our service
// builder.Services.AddScoped<SupabaseTodoService>();

// await builder.Build().RunAsync();

