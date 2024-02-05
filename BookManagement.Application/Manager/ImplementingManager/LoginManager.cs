
using BookManagement.Application.DTO.Request;
using BookManagement.Application.Helpers;
using BookManagement.Application.Manager.Interfaces;
using BookManagement.Domain.Interface;
using BookManagement.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static BookManagement.Infrastructure.Services.Common;

namespace BookManagement.Application.Manager.ImplementingManager
{
    public class LoginManager : ILoginManager
    {
        public IConfiguration _configuration;
        private readonly ILoginService _service;
        public LoginManager(ILoginService loginService, IConfiguration config)
        {
            _service = loginService;
            _configuration = config;
        }

        public async Task<ServiceResult<string>> GetJWTToken(LoginRequestDTO loginRequestDTO)
        {
            var serviceResult = new ServiceResult<string>();

            try
            {
                var staff = await _service.GetStaffByUsername(loginRequestDTO.Username);
                if (staff == null)
                {
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "This username doesn't exist";
                    serviceResult.Data = null;
                    return serviceResult;
                }
                bool confirmResult = PasswordHasher.Confirm(loginRequestDTO.Password, staff.Password, PasswordHasher.Supported_HA.SHA256);
                if (!confirmResult)
                {
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "Incorrect password";
                    serviceResult.Data = null;
                    return serviceResult;

                }
                var claims = new[] {
                        new Claim("Username", staff.Username.ToString()),
                        new Claim(ClaimTypes.Role, staff.StaffType.ToString()),
                        new Claim("staffId", staff.StaffId.ToString())
                         };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(15),
                    signingCredentials: credentials);
                var userToken = new JwtSecurityTokenHandler().WriteToken(token);
                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Jwt Token Obtained Successfully";
                serviceResult.Data = userToken;
                return serviceResult;
            }
            catch
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "Error occurred while fetching user";
                serviceResult.Data = null;
                return serviceResult;

            }

        }

    }
}
