
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Supabase;

public class SupabaseAuthStateProvider : AuthenticationStateProvider
{
    private readonly Client _supabaseClient;
    private readonly ILocalStorageService _localStorage;

    public SupabaseAuthStateProvider(Client client, ILocalStorageService localStorageService)
    {
        _supabaseClient = client;
        _localStorage = localStorageService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var session = await _localStorage.GetItemAsync<string>("supabase_session");

        if (session != null)
        {
            var user = _supabaseClient.Auth.CurrentUser;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user?.Email ?? string.Empty)
            };

            var identity = new ClaimsIdentity(claims, "Supabase");
            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationState(principal);
        }

        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public void NotifyUserAuthentication(Supabase.Gotrue.User user)
    {
        var identity = new ClaimsIdentity(new[]{
            new Claim(ClaimTypes.Name, user.Email!)
        }, "Supabase");

        var principal = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    }

    public void NotifyUserLogout()
    {
        _localStorage.RemoveItemAsync("supabase_session");
        var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
    }
}