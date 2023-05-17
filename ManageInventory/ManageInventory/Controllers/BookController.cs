using ManageInventory.Data;
using ManageInventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManageInventory.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Book> books = _context.Books.ToList(); 

            return View(books);
        }

        public IActionResult Details(string Id) 
        {
            Book? book = _context.Books.Where(b => b.Isbn == Id).FirstOrDefault();
            return View(book);
        }
    }
}
