using LibraryManagementWeb.Models.Models.Security;
using LibraryManagementWeb.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly HttpClient _httpClient;

        public TokenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> GetNewToken(ApiAccount accountToUse)
        {
            var url = $"api/Tokens?username={accountToUse.Username}&password={accountToUse.Password}&grant_Type={accountToUse.GrantType}";

            try
            {
                var response = await _httpClient.PostAsync(url, null);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
