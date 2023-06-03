using AutoMapper;
using ManageInventory.Persistence.Data;
using ManageInventory.DTO;
using ManageInventory.Persistence.Entities;
using ManageInventory.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ManageInventory.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public BookController(
            Repositories.IBookRepository @object,
            LibraryContext context,
            IMapper mapper,
            IBookService bookService
            )
        {
            _context = context;
            _mapper = mapper;
            _bookService = bookService;
        }


        [HttpGet]
        [ActionName("Index")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return View((List<Book>)await _bookService.GetBooksAsync());
        }

        [HttpGet]
        public IActionResult Details(Book? book, string Id)
        {
            book = _context.Books.Where(b => b.Isbn == Id)
                .Include(b => b.IdEditorialNavigation)
                .FirstOrDefault();
            BookDetailDTO? bookDetailDTO = _mapper.Map<BookDetailDTO>(book);
            return View(bookDetailDTO);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            List<DropDownListModel> listEditorials = null!;

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
        //[Authorize(Roles = "Admin")]
        [ActionName("Create")]
        public async Task<ActionResult<Book>> AddBooks(Book book, AuthorsHasBook authorsHasBook)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            else
            {
                await _bookService.AddBookAsync(book, authorsHasBook);
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(string Id)
        {
            Book? book = await _bookService.BookByIsbnAsync(Id);
            return View(book);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            else
            {
                await _bookService.MergeBookAsync(book);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string Id)
        {
            Book? book = await _bookService.BookByIsbnAsync(Id);
            return View(book);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Book book)
        {
            await _bookService.DeleteBookAsync(book);
            return RedirectToAction("Index");
        }

    }
}
