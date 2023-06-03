using ManageInventory.Persistence.Entities;

namespace ManageInventory.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> AddBookAsync(Book book, AuthorsHasBook authorsHasBook);

        Task<Book> BookByIsbnAsync(string isbn);

        Task<Book> MergeBookAsync(Book book);

        Task<Book> DeleteBookAsync(Book book);
    }
}
