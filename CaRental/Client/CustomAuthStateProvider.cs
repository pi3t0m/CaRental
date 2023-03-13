using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace CaRental.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public CustomAuthStateProvider(ILocalStorageService localStorage) 
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(new ClaimsPrincipal());

            string username = await _localStorage.GetItemAsStringAsync("username");
            
            if (!string.IsNullOrEmpty(username))
            {
                /*username = username.Substring(1, username.Length - 2);
                Console.WriteLine(username);*/
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }, "test authentication type");

                state = new AuthenticationState(new ClaimsPrincipal(identity));
            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}
