using AutoMapper;
using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using BookManagement.Application.Manager.Interfaces;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Interface;
using BookManagement.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookManagement.Infrastructure.Services.Common;

namespace BookManagement.Application.Manager.ImplementingManager
{
    public class BookManager : IBookManager
    {
        private readonly IBookService _service;
        private readonly IMapper _mapper;
        public BookManager(IBookService bookService, IMapper mapper)
        {
            _service = bookService;
            _mapper = mapper;

        }
        public async Task<ServiceResult<bool>> AddBook(BookRequestDTO bookRequestDTO)
        {
            var serviceResult = new ServiceResult<bool>();
            try
            {
                var bookDomain = new Book()
                {
                    BookId = bookRequestDTO.BookId,
                    BookAuthor = bookRequestDTO.BookAuthor,
                    BookName = bookRequestDTO.BookName,
                    BookDescription = bookRequestDTO.BookDescription,
                    BookStatus = bookRequestDTO.BookStatus,
                    BookQuantity = bookRequestDTO.BookQuantity,
                };
                var data = await _service.AddBook(bookDomain);
                serviceResult.Status = data ? StatusType.Success : StatusType.Failure;
                serviceResult.Message = data ? "Book Added Sucessfully" : "Failed to add book";
                serviceResult.Data = data;
                return serviceResult;
            }
            catch
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "An error occurred while adding the book";
                serviceResult.Data = false;
                return serviceResult;

            }
        }

        public async Task<ServiceResult<bool>> DeleteBook(int id)
        {
            var serviceResult = new ServiceResult<bool>();

            try
            {
                var book = await _service.GetBookById(id);
                if (book == null)
                {
                    // Book does not exist
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "Book not found";
                    serviceResult.Data = false;

                    return serviceResult;
                }

                var result = await _service.DeleteBook(id);

                serviceResult.Status = result ? StatusType.Success : StatusType.Failure;
                serviceResult.Message = result ? "Book deleted successfully" : "Failed to delete book";
                serviceResult.Data = result;

                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "An error occurred while deleting the book";
                serviceResult.Data = false;

                return serviceResult;
            }
        }

        public async Task<ServiceResult<BookResponseDTO>> GetBookById(int id)
        {
            var serviceResult = new ServiceResult<BookResponseDTO>();
            try
            {
                var book = await _service.GetBookById(id);
                if (book == null)
                {
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "Book not found";
                    serviceResult.Data = null;
                    return serviceResult;
                }
                var bookResponse = _mapper.Map<BookResponseDTO>(book);

                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Book retrieved successfully";
                serviceResult.Data = bookResponse;

                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "An error occurred while retrieving the book";
                serviceResult.Data = null;

                return serviceResult;

            }
        }

        public async Task<ServiceResult<List<BookResponseDTO>>> GetBooks()
        {
            var serviceResult = new ServiceResult<List<BookResponseDTO>>();

            try
            {
                var books = await _service.GetBooks();
                var result = (from book in books
                              where book.DateDeleted == null
                              select new BookResponseDTO()
                              {
                                  BookId = book.BookId,
                                  BookAuthor = book.BookAuthor,
                                  BookName = book.BookName,
                                  BookDescription = book.BookDescription,
                                  BookStatus = book.BookStatus,
                                  BookQuantity = book.BookQuantity,

                              }).ToList();

                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Books retrieved successfully";
                serviceResult.Data = result;

                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "An error occurred while retrieving the books";
                serviceResult.Data = null;

                return serviceResult;
            }
        }



        public async Task<ServiceResult<bool>> UpdateBook(BookRequestDTO bookRequestDTO)
        {
            var serviceResult = new ServiceResult<bool>();
            try
            {
                var book = await _service.GetBookById(bookRequestDTO.BookId);
                if (book == null)
                {
                    serviceResult.Status = StatusType.Failure;
                    serviceResult.Message = "Book could not be found";
                    serviceResult.Data = false;
                    return serviceResult;
                }
                _mapper.Map(bookRequestDTO,book);
                var result = _service.UpdateBookStatus(book);
                serviceResult.Status = StatusType.Success;
                serviceResult.Message = "Book Update Sucessfully";
                serviceResult.Data = true;
                return serviceResult;

            }
            catch
            {
                serviceResult.Status = StatusType.Failure;
                serviceResult.Message = "An error occurred while retrieving the books";
                serviceResult.Data = false;

                return serviceResult;

            }
        }
    }
}
