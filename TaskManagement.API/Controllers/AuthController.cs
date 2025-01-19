using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetAuthToken()
        {
            try
            {
                var token = await _authenticationService.GetAccessTokenAsync();
                return Ok(new { AccessToken = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error al obtener el token de acceso", Error = ex.Message });
            }
        }
    }
}
