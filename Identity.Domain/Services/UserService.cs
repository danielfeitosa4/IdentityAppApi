using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

namespace Identity.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IKeycloakService _keycloakService;

        public UserService(IKeycloakService keycloakService)
        {
            _keycloakService = keycloakService;
        }

        public async Task<string> Create(UserModel userModel)
        {
            try
            {
                string token = await _keycloakService.Token();

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/admin/realms/salti/users");
                request.Headers.Add("Authorization", $"Bearer {token}");

                string json = JsonConvert.SerializeObject(userModel, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                request.Content = new StringContent(json, null, "application/json");
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return "Usuário criado com sucesso.";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
