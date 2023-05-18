using ManageInventory.Data;
using ManageInventory.Models;
using ManageInventory.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;

namespace ManageInventory.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _context;

        //public BookController(LibraryContext context)
        //{
        //    //_context = context;

        //}

        //public IActionResult Index()
        //{
        //    List<Book> books = _context.Books.ToList();

        //    return View(books);
        //}

        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository iBookRepository, LibraryContext context)
        {
            _bookRepository = iBookRepository;
            _context = context;
        }


        [HttpGet]
        [AllowAnonymous]
        [ActionName("Index")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            IEnumerable<Book>? ResultBooksList = default;
            try
            {
                ResultBooksList = (List<Book>)await _bookRepository.GetBooksAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message, "Error al mostrar la lista de libros");
            }

            return View(ResultBooksList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<DropDownListModel> listEditorials = null;

            listEditorials = (from d in _context.Editorials.Where(e => e.IdEditorial != 0)
                    select new DropDownListModel
                    {
                        Id = d.IdEditorial,
                        Name = d.Name
                    }).ToList();
            List<SelectListItem> itemsEditorials = listEditorials.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Name?.ToString(),
                    Value = d.Id.ToString()
                };
            });
            ViewBag.itemsEditorials = itemsEditorials;


            List<DropDownListModel>? listAuthors = null;

            listAuthors = (from d in _context.Authors.Where(e => e.IdAuthor != 0)
                    select new DropDownListModel
                    {
                        Id = d.IdAuthor,
                        Name = d.Name,
                        LastName = d.LastName
                    }).ToList();
            List<SelectListItem> itemsAuthor = listAuthors.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Name?.ToString() + " " + d.LastName?.ToString(),
                    Value = d.Id.ToString()
                };
            });
            ViewBag.itemsAuthor = itemsAuthor;

            Book? book = new Book();
            return View(book);
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("Create")]
        public async Task<ActionResult<Book>> AddBooks(Book book, AuthorsHasBook authorsHasBook)
        {
            await _bookRepository.AddBook(book, authorsHasBook);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(string Id) 
        {
            Book? book = _context.Books.Where(b => b.Isbn == Id).FirstOrDefault();
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _context.Attach(book);
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(string Id)
        {
            Book? book = _context.Books.Where(b => b.Isbn == Id).FirstOrDefault();
            return View(book);
        }
        [HttpPost]
        public IActionResult Delete(Book book)
        {
            _context.Attach(book);
            _context.Remove(book).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult<Book>> Details(string Id) 
        {
            Book? book = await _context.Books.Where(b => b.Isbn == Id).FirstOrDefaultAsync();
            return View(book);
        }
    }
}
