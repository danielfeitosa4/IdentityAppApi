using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using System.Net.Http.Json;

namespace Identity.Domain.Services
{
    public class AccountService : IAccountService
    {
        public async Task<string> Login(LoginModel loginModel)
        {
            try
            {
                HttpClient client = new();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/realms/salti/protocol/openid-connect/token");
                var collection = new List<KeyValuePair<string, string>>
                {
                    new("client_id", "IdentityApp"),
                    new("username", loginModel.Username),
                    new("password", loginModel.Password),
                    new("grant_type", "password"),
                    new("client_secret", "qCcLKD4W6inoOQCqIJDyAYKtD3C07bh2")
                };
                var content = new FormUrlEncodedContent(collection);
                request.Content = content;

                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return "Usuário inexistente";
                }

                TokenModel tokenModel = await response.Content.ReadFromJsonAsync<TokenModel>();

                return tokenModel.AccessToken;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Token(LoginModel model)
        {
            try
            {
                HttpClient client = new();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/realms/salti/protocol/openid-connect/token");
                var collection = new List<KeyValuePair<string, string>>
                {
                    new("client_id", "IdentityApp"),
                    new("username", model.Username),
                    new("password", model.Password),
                    new("grant_type", "password"),
                    new("client_secret", "qCcLKD4W6inoOQCqIJDyAYKtD3C07bh2")
                };
                var content = new FormUrlEncodedContent(collection);
                request.Content = content;

                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return "Usuário inexistente";
                }

                TokenModel tokenModel = await response.Content.ReadFromJsonAsync<TokenModel>();

                return tokenModel.AccessToken;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
