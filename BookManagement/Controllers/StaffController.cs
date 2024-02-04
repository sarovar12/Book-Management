using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using BookManagement.Application.Manager.Interfaces;
using BookManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StaffController : ControllerBase
    {
        private readonly IStaffManager _staffManager;
        public StaffController(IStaffManager staffManager)
        {
            _staffManager = staffManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(StaffRequestDTO staffRequestDTO)
        {
            var result = await _staffManager.AddStaff(staffRequestDTO);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(Guid id)
        {
            var result = await _staffManager.DeleteStaff(id);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffById(Guid id)
        {
            var result = await _staffManager.GetStaffById(id);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpGet]
        public async Task<IActionResult> GetStaffs()
        {
            var result = await _staffManager.GetStaffs();
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaff(Guid id, StaffResponseDTO staffResponseDTO)
        {
            if (id != staffResponseDTO.StaffId)
            {
                return BadRequest("Invalid staff ID");
            }

            var result = await _staffManager.UpdateStaffs(staffResponseDTO);

            if (result.Status == StatusType.Success)
            {
                return Ok(result.Message);
            }

            return NotFound(result.Message);
        }
    }
}
