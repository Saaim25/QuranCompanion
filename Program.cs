using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QuranCompanion;
using Blazored.LocalStorage;
using Supabase;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var options = new SupabaseOptions
{
    AutoConnectRealtime = false
};

    
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new Client("https://jjqfsqaidmwiulyfzozn.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImpqcWZzcWFpZG13aXVseWZ6b3puIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTkwNzU5NDEsImV4cCI6MjA3NDY1MTk0MX0.6XOMZx6DaeFkBLbL5AD-raEkD05fv3y5lr-v0IzSL_Q"));
builder.Services.AddScoped<AuthenticationStateProvider, SupabaseAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<SupabaseAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<SupabaseAuthStateProvider>());
builder.Services.AddAuthorizationCore();


await builder.Build().RunAsync();

internal class SupabaseAuthenticationStateProvider
{
}