using LibraryManagementWeb.Models.Models.Security;
using LibraryManagementWeb.Services.Interfaces;
using LibraryManagementWeb.Services.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Business.Security
{
    public class TokenManager : ITokenManager
    {
        private readonly NameValueCollection _tokenUserValues; // AppSettings
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public TokenManager(IConfiguration inConfig, ITokenService tokenService)
        {
            _config = inConfig;
            // Fetching the appsettigns values for the token user
            _tokenUserValues = GetAuthorizationSetting();
            _tokenService = tokenService;
        }

        private NameValueCollection GetAuthorizationSetting()
        {
            IConfigurationSection? authSetting = _config.GetSection("Authorization");
            NameValueCollection? tokenUserValues = new NameValueCollection();
            foreach (var key in authSetting.GetChildren())
            {
                tokenUserValues.Add(key.Key, key.Value);
            }
            return tokenUserValues;

        }

        public async Task<string?> GetToken(TokenStateEnum currentState)
        {
            string? foundToken = null;
            if (currentState == TokenStateEnum.Valid)
            {
                foundToken = GetTokenExisting();
            }
            else if (currentState == TokenStateEnum.Invalid)
            {
                foundToken = await GetTokenNew();
            }
            return foundToken;
        }

        private async Task<string?> GetTokenNew()
        {
            string? foundToken = null;

            // Retrieving account data
            ApiAccount accountData = GetApiAccountCredentials();

            // Access a new Token from the API

            foundToken = await _tokenService.GetNewToken(accountData);

            if (foundToken != null)
            {
                JWT.CurrentJWT = foundToken;
            }

            return foundToken;
        }

        private ApiAccount GetApiAccountCredentials()
        {
            ApiAccount apiAccount = new ApiAccount();

            if (_tokenUserValues.HasKeys())
            {
                apiAccount.GrantType = _tokenUserValues["Role"];
                apiAccount.Password = _tokenUserValues["Password"];
            }
            //apiAccount.Username = GetApplicationAssemblyName();
            apiAccount.Username = _tokenUserValues["UserName"];;

            return apiAccount;
        }

        private string? GetApplicationAssemblyName()
        {
            string? assemblyName = System.Reflection.Assembly.GetCallingAssembly().GetName().Name;
            return assemblyName;
        }

        private string? GetTokenExisting()
        {
            string? foundToken = JWT.CurrentJWT;
            return foundToken;

        }


    }
}
