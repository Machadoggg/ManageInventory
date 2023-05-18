using ManageInventory.Models;

namespace ManageInventory.Repositories
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetBooksAsync();
        public Task<Book> AddBook(Book book, AuthorsHasBook authorsHasBook);
    }
}
