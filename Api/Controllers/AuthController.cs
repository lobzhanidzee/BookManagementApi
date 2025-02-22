using BookManagementApi.Data;
using BookManagementApi.Models;
using BookManagementApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        public AuthController(JwtService jwtService) =>
            _jwtService = jwtService;

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            var user = await _jwtService.Authenticate(request);
            if (user == null)
                return Unauthorized("Invalid credentials");

            return user;
        }
    }
}
