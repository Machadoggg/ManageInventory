using ManageInventory.Data;
using ManageInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageInventory.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public async Task<Book> AddBook(Book book)
        {
            var newBook = new Book { 
                Isbn = book.Isbn,
                Title = book.Title,
                Sinopsis = book.Sinopsis,
                NumberPages = book.NumberPages
            };
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
