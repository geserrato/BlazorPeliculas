using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorPeliculas.Client.Auth;

public class ProveedorAutenticacionJWT : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        throw new NotImplementedException();
    }
}
