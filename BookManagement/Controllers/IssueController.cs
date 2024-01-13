using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using BookManagement.Application.Manager.ImplementingManager;
using BookManagement.Application.Manager.Interfaces;
using BookManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueManager _issueManager;
        public IssueController(IIssueManager issueManager)
        {
            _issueManager = issueManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddIssue(IssueRequestDTO issueRequestDTO)
        {
            var result = await _issueManager.AddIssue(issueRequestDTO);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssue(Guid id)
        {
            var result = await _issueManager.DeleteIssue(id);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIssueById(Guid id)
        {
            var result = await _issueManager.GetIssueById(id);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllIssues()
        {
            var result = await _issueManager.GetIssues();
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIssue(Guid id, IssueUpdateResponseDTO issueResponseDTO)
        {
            if (id != issueResponseDTO.IssueId)
            {
                return BadRequest("Invalid book ID");
            }

            var result = await _issueManager.UpdateIssue(issueResponseDTO);

            if (result.Status == StatusType.Success)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);

        }

    }
}
