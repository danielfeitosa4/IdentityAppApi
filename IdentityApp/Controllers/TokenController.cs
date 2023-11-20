using Identity.Domain.Interfaces;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IKeycloakService _keycloakService;

        public TokenController(IKeycloakService keycloakService)
        {
            _keycloakService = keycloakService;
        }

        [HttpPost]
        public async Task<IActionResult> Token()
        {
            var token = await _keycloakService.Token();

            return Ok(token);
        }
    }
}
