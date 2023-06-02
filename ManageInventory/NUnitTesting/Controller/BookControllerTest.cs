using AutoMapper;
using ManageInventory.Controllers;
using ManageInventory.Data;
using ManageInventory.DTO;
using ManageInventory.Persistence.Entities;
using ManageInventory.Repositories;
using ManageInventory.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace NUnitTesting.Controller
{
    public class BookControllerTest
    {
        private BookController _bookController;
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

            _bookController = new BookController(_bookRepositoryMock.Object, _contextMock.Object, _mapperMock.Object, _bookServiceMock.Object);
        }


        [Test]
        public async Task GetBooks_Index()
        {
            // Arrange
            var expectedBooks = new List<Book>();
            _bookServiceMock.Setup(repo => repo.GetBooksAsync()).ReturnsAsync(expectedBooks);

            // Act
            var result = await _bookController.GetBooks();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result.Result);
        }


        [Test]
        public async Task Details_Book()
        {
            // Arrange
            var bookId = "123";
            var book = new Book { Isbn = bookId };
            var bookDetailDTO = new BookDetailDTO();
            _contextMock.Setup(c => c.Books).Returns(GetMockDbSet(new[] { book }));
            _mapperMock.Setup(m => m.Map<BookDetailDTO>(It.IsAny<Book>())).Returns(bookDetailDTO);

            // Act
            var result = _bookController.Details(null, bookId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(bookDetailDTO, result.Model);
        }


        [Test]
        public async Task AddBooks_WithValidData_RedirectsToIndex()
        {
            // Arrange
            var book = new Book();
            var authorsHasBook = new AuthorsHasBook();
            _bookRepositoryMock.Setup(repo => repo.AddBookAsync(book, authorsHasBook)).Returns(Task.FromResult<Book>(default));

            // Act
            var result = await _bookController.AddBooks(book, authorsHasBook) as ActionResult<Book>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToActionResult>(result.Result);
            var redirectResult = result.Result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }


        [Test]
        public async Task Edit_WithValidBook_RedirectsToIndex()
        {
            // Arrange
            var book = new Book();
            _bookRepositoryMock.Setup(repo => repo.MergeBookAsync(book)).Returns(Task.FromResult<Book>(default));

            // Act
            var result = await _bookController.Edit(book) as ActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }


        [Test]
        public async Task Edit_WithInvalidBook_ReturnsViewResult()
        {
            // Arrange
            var book = new Book();
            _bookController.ModelState.AddModelError("Title", "Title is required");

            // Act
            var result = await _bookController.Edit(book) as ActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(book, viewResult.Model);
        }


        [Test]
        public async Task Delete_WithValidBook_RedirectsToIndex()
        {
            // Arrange
            var book = new Book();
            _bookRepositoryMock.Setup(repo => repo.DeleteBookAsync(book)).Returns(Task.FromResult<Book>(default));

            // Act
            var result = await _bookController.Delete(book) as IActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }



        private DbSet<T> GetMockDbSet<T>(T[] data) where T : class
        {
            var queryableData = data.AsQueryable();
            var mockDbSet = new Mock<DbSet<T>>();
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableData.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableData.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryableData.GetEnumerator());
            return mockDbSet.Object;
        }



    }
}
