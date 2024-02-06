using BookManagement.Application.DTO.Request;
using BookManagement.Application.DTO.Response;
using BookManagement.Application.Manager.ImplementingManager;
using BookManagement.Application.Manager.Interfaces;
using BookManagement.Controllers;
using BookManagement.Domain.Entities;
using BookManagement.Infrastructure.Repository;
using BookManagement.Infrastructure.Services;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static BookManagement.Infrastructure.Services.Common;

namespace BookManagement.Tests.Controller
{
    public class BooksControllerTests
    {
        private readonly IBookManager _bookManager;

        public BooksControllerTests()
        {
            _bookManager = A.Fake<IBookManager>();

        }

        [Fact]
        public void BookController_GetBooks_ReturnOk()
        {
            //Arrange
            var books = A.Fake<List<Book>>();
            var controller = new BookController(_bookManager);


            //Act
            var result = controller.GetBooks();


            //Assertions
            result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));
       
        }

        [Fact]
        public void BooksController_AddBook_ReturnsOk()
        {
            var bookRequestDTO = A.Fake<BookRequestDTO>();
            var controller = new BookController(_bookManager);

            //Act
            var result = controller.AddBook(bookRequestDTO) ;

            //Assert

            result.Should().NotBeNull();
            result.Result.Should().BeOfType(typeof(OkObjectResult));


        }

        [Fact]
        public async void BooksController_AddBooks_ReturnsBadRequest()
        {
            var bookRequestDTO = A.Fake<BookRequestDTO>();
            var controller = new BookController(_bookManager);

            var result = await controller.AddBook(bookRequestDTO) as BadRequestObjectResult;

            result.Should().BeNull();
         }
    }
}
