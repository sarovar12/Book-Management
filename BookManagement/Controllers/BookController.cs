using BookManagement.Application.DTO.Request;
using BookManagement.Application.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BookManagement.Infrastructure.Services;
using System.Text.Json;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager _bookManager;
        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;

        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookRequestDTO bookRequestDTO)
        {
            var result = await _bookManager.AddBook(bookRequestDTO);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookManager.DeleteBook(id);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var result = await _bookManager.GetBookById(id);
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var result = await _bookManager.GetBooks();
            if (result.Status == StatusType.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookRequestDTO bookRequestDTO)
        {
            if (id != bookRequestDTO.BookId)
            {
                return BadRequest("Invalid book ID");
            }

            var result = await _bookManager.UpdateBook(bookRequestDTO);

            if (result.Status == StatusType.Success)
            {
                return Ok(result.Message);
            }

            return NotFound(result.Message);
        }

    }
}
