using BookManagement.Domain.Interface;
using BookManagement.Domain.Entities;
using BookManagement.Infrastructure.Repository;


namespace BookManagement.Infrastructure.Services
{
    public class BookServices : IBookService
    {
        private readonly IServiceFactory _factory;

        public BookServices(IServiceFactory serviceFactory)
        {
            _factory = new ServiceFactory();

        }
        public async Task<bool> AddBook(Book book)
        {
            try
            {
                var service = _factory.GetInstance<Book>();
                await service.AddAsync(book);
                return true;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<bool> DeleteBook(int id)
        {
            try
            {
                var service = _factory.GetInstance<Book>();
                var user = await service.FindAsync(id);
                if (user == null)
                {
                    return false;
                }
                user.DateDeleted = DateTime.Now;
                user.BookStatus = Domain.Enum.BookAvailable.NotAvailable;
                await service.UpdateAsync(user);
                return true;
            }
            catch (Exception ex) { throw; }
        }
        public async Task<Book> GetBookById(int id)
        {
            var service = _factory.GetInstance<Book>();
            var books = await service.ListAsync();
            var bookById = books.FirstOrDefault(book => book.BookId == id && book.DateDeleted == null);
            if(bookById == null)
            {
                return null;
            }
            return bookById;

        }

        public async Task<List<Book>> GetBooks()
        {
            try
            {
                var service = _factory.GetInstance<Book>();
                var result = await service.ListAsync();
                return result;
            }
            catch (Exception ex) { throw; }
        }
        public async Task<bool> UpdateBookStatus(Book book)
        {
            try
            {
                var service = _factory.GetInstance<Book>();
                var bookData = await service.FindAsync(book.BookId);
                if (bookData == null || !bookData.DateDeleted.HasValue )
                {
                    return false;
                }
                bookData.BookName = book.BookName;
                bookData.BookDescription = book.BookDescription;

                

                await service.UpdateAsync(bookData);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
