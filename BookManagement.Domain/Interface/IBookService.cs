

using BookManagement.Domain.Entities;


namespace BookManagement.Application.Interface
{
    public interface IBookService
    {

        //This thing is after mapped and ready to go to database for dirty action.
        Task<bool> AddBook (Book book);
        Task<List<Book>> GetBooks();
        Task<Book>GetBookById(int id);
        Task<bool> UpdateBookStatus(Book book);
        Task<bool> DeleteBook(int id);
    }
}
