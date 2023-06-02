using ManageInventory.Persistence.Entities;

namespace ManageInventory.Repositories
{
    public interface IBookRepository
    {
        /// <summary>
        /// Get all book list
        /// </summary>
        /// <returns>Book list inventory</returns>
        Task<IEnumerable<Book>> GetBooksAsync();

        /// <summary>
        /// Create new book
        /// </summary>
        /// <param name="book"></param>
        /// <param name="authorsHasBook"></param>
        /// <returns>Book created</returns>
        Task<Book> AddBookAsync(Book book, AuthorsHasBook authorsHasBook);

        /// <summary>
        /// Get book by Id
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns>A book object</returns>
        Task<Book> BookByIsbnAsync(string isbn);

        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Book updated</returns>
        Task<Book> MergeBookAsync(Book book);

        /// <summary>
        /// Delete book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Task<Book> DeleteBookAsync(Book book);
    }
}
