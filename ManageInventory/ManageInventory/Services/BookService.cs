using ManageInventory.Persistence.Entities;
using ManageInventory.Repositories;

namespace ManageInventory.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _IBookRepository;

        public BookService(IBookRepository IBookRepository)
        {
            _IBookRepository = IBookRepository;
        }


        public async Task<Book> AddBookAsync(Book book, AuthorsHasBook authorsHasBook)
        {
            var addBook = await _IBookRepository.AddBookAsync(book, authorsHasBook);
            return addBook;
        }

        public async Task<Book> BookByIsbnAsync(string isbn)
        {
            var book = await _IBookRepository.BookByIsbnAsync(isbn);
            return book;
        }

        public async Task<Book> DeleteBookAsync(Book book)
        {
            var deleteBook = await _IBookRepository.DeleteBookAsync(book);
            return deleteBook;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var books = await _IBookRepository.GetBooksAsync();
            return books;
        }

        public async Task<Book> MergeBookAsync(Book book)
        {
            var mergeBook = await _IBookRepository.MergeBookAsync(book);
            return mergeBook;
        }
    }
}
