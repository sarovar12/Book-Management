using BookManagement.Application.DTO.Request;
using BookManagement.Application.Manager.ImplementingManager;
using BookManagement.Application.Manager.Interfaces;
using BookManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginManager _loginManager;
        public LoginController(ILoginManager loginManager)
        {
            _loginManager = loginManager;
            
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginRequestDTO loginRequestDTO)
        {
            var result = await _loginManager.GetJWTToken(loginRequestDTO);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
