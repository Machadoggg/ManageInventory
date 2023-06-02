using ManageInventory.Data;
using ManageInventory.Persistence.Entities;
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


        public async Task<Book> AddBookAsync(Book book, AuthorsHasBook authorsHasBook)
        {
            var newBook = new Book
            {
                Isbn = book.Isbn,
                IdEditorial = book.IdEditorial,
                Title = book.Title,
                Sinopsis = book.Sinopsis,
                NumberPages = book.NumberPages
            };
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

            _context.Attach(authorsHasBook);
            _context.Entry(authorsHasBook).State = EntityState.Added;
            _context.SaveChanges();

            return newBook;
        }

        public async Task<Book> BookByIsbnAsync(string isbn)
        {
            Book? ResultBookByIsbn = default;
            try
            {
                ResultBookByIsbn = await _context.Books.FirstOrDefaultAsync(W => W.Isbn == isbn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Error in ID selected");
            }
            return ResultBookByIsbn;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> MergeBookAsync(Book book)
        {
            Book ResultEditBook = default;
            try
            {
                _context.Attach(book).State = EntityState.Modified;
                if (await _context.SaveChangesAsync() > 0)
                {
                    ResultEditBook = book;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Error to edit book");
            }
            return ResultEditBook;
        }

        public async Task<Book> DeleteBookAsync(Book book)
        {
            Book ResultDeleteBook = default;
            try
            {
                var relatedRecords = await _context.AuthorsHasBooks
                    .Where(r => r.Isbn == book.Isbn)
                    .ToListAsync();
                _context.Remove(book).State = EntityState.Deleted;
                _context.RemoveRange(relatedRecords);
                if (await _context.SaveChangesAsync() > 0)
                {
                    ResultDeleteBook = book;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Error to delete book");
            }
            return ResultDeleteBook;
        }
    }
}
