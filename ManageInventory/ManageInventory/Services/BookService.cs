using ManageInventory.Data;
using ManageInventory.Persistence.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ManageInventory.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;
        public BookService(LibraryContext context)
        {
            _context = context;
        }


        public async Task<Book> AddBookAsync(Book book, AuthorsHasBook authorsHasBook)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> BookByIsbnAsync(string isbn)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Isbn == isbn); 

            return book;
        }

        public async Task<Book> DeleteBookAsync(Book book)
        {
            _context.Books.Remove(book); 
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var books = await _context.Books.ToListAsync(); 

            return books;
        }

        public async Task<Book> MergeBookAsync(Book book)
        {
            _context.Books.Update(book); 
            await _context.SaveChangesAsync();

            return book;
        }
    }
}
