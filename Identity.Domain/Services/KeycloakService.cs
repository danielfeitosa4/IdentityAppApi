using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Identity.Domain.Services
{
    public class KeycloakService : IKeycloakService
    {
        public async Task<string> Token()
        {
            try
            {
                HttpClient client = new();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/realms/salti/protocol/openid-connect/token");
                var collection = new List<KeyValuePair<string, string>>
                {
                    new("client_id", "IdentityApp"),
                    new("username", "daniel"),
                    new("password", "root123"),
                    new("grant_type", "password"),
                    new("client_secret", "qCcLKD4W6inoOQCqIJDyAYKtD3C07bh2")
                };
                var content = new FormUrlEncodedContent(collection);
                request.Content = content;

                var response = await client.SendAsync(request);

                if(!response.IsSuccessStatusCode)
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
