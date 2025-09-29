using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QuranCompanion;
using Supabase;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var options = new SupabaseOptions
{
    AutoConnectRealtime = false
};

var supabase = new Supabase.Client(
    "https://jjqfsqaidmwiulyfzozn.supabase.co",   // your project URL
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImpqcWZzcWFpZG13aXVseWZ6b3puIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTkwNzU5NDEsImV4cCI6MjA3NDY1MTk0MX0.6XOMZx6DaeFkBLbL5AD-raEkD05fv3y5lr-v0IzSL_Q",                      // your anon/public key
    options);

builder.Services.AddSingleton(supabase);

await supabase.InitializeAsync();

await builder.Build().RunAsync();
