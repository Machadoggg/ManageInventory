using ManageInventory.Data;
using ManageInventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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


        [HttpGet]
        public IActionResult Create()
        {
            List<Editorial> editorialList = _context.Editorials.ToList();
            ViewBag.Editorial = editorialList;

            Book? book = new Book();
            return View(book);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            book.IdEditorial = 1;
            _context.Attach(book);
            _context.Entry(book).State = EntityState.Added;
            _context.SaveChanges();
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
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Details(string Id) 
        {
            Book? book = _context.Books.Where(b => b.Isbn == Id).FirstOrDefault();
            return View(book);
        }
    }
}
