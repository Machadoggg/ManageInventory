using AutoMapper;
using ManageInventory.Controllers;
using ManageInventory.Data;
using ManageInventory.Persistence.Entities;
using ManageInventory.Repositories;
using ManageInventory.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace NUnitTesting.Logic
{
    public class BookLogicTest
    {
        private Mock<IBookRepository> _bookRepositoryMock;
        private Mock<LibraryContext> _contextMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IBookService> _bookServiceMock;

        [SetUp]
        public void Setup()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _contextMock = new Mock<LibraryContext>();
            _mapperMock = new Mock<IMapper>();
            _bookServiceMock = new Mock<IBookService>();
        }


        [Test]
        public async Task AddBookAsync_WithValidData_ReturnsNewBook()
        {
            // Arrange
            var book = new Book
            {
                Isbn = "12345678901",
                IdEditorial = 1,
                Title = "Sample Book",
                Sinopsis = "Sample sinopsis",
                NumberPages = "100"
            };
            var authorsHasBook = new AuthorsHasBook
            {
                IdAuthor = 1,
                Isbn = "12345678901"
            };

            // Mock the dependencies
            var bookRepositoryMock = new Mock<IBookRepository>();
            var contextMock = new Mock<LibraryContext>();
            var mapperMock = new Mock<IMapper>();

            // Set up behavior for the mocked dependencies
            bookRepositoryMock.Setup(repo => repo.AddBookAsync(It.IsAny<Book>(), It.IsAny<AuthorsHasBook>()))
                .ReturnsAsync(book);
            contextMock.Setup(c => c.SaveChangesAsync(CancellationToken.None))
                .Returns(Task.FromResult(0));
            var bookController = new BookController(bookRepositoryMock.Object, contextMock.Object, mapperMock.Object, _bookServiceMock.Object);

            // Act
            var result = await bookController.AddBooks(book, authorsHasBook);

            // Assert
            Assert.IsInstanceOf<ActionResult<Book>>(result);


        }

    }
}
