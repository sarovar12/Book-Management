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
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;

        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentRequestDTO studentRequestDTO)
        {
            var result = await _studentManager.CreateStudent(studentRequestDTO);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var result = await _studentManager.DeleteStudent(id);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var result = await _studentManager.GetStudentByID(id);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var result = await _studentManager.GetStudents();
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, StudentResponseDTO studentResponseDTO)
        {
            if (id != studentResponseDTO.StudentId)
            {
                return BadRequest("Invalid Student ID");
            }

            var result = await _studentManager.UpdateStudent(studentResponseDTO);

            if (result.Status == StatusType.Success)
            {
                return Ok(result.Message);
            }

            return NotFound(result.Message);
        }


    }
}
