using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using static BookManagement.Infrastructure.Services.Common;

namespace BookManagement.Application.Manager.Interfaces
{
    public interface IBookManager
    {
        Task<ServiceResult<bool>> AddBook(BookRequestDTO bookRequestDTO);
        Task<ServiceResult<bool>> DeleteBook(int id);
        Task<ServiceResult<BookResponseDTO>> GetBookById(int id);
        Task<ServiceResult<List<BookResponseDTO>>> GetBooks();
        Task<ServiceResult<bool>> UpdateBooks(BookRequestDTO bookRequestDTO);
    }
}
