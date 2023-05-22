using ManageInventory.Data;
using ManageInventory.Models;
using ManageInventory.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ManageInventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryContext _contex;

        public HomeController(ILogger<HomeController> logger, LibraryContext contex)
        {
            _logger = logger;
            _contex = contex;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {

                //var obj = _contex.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                //if (obj != null)
                //{
                //    Session["UserID"] = obj.UserId.ToString();
                //    Session["UserName"] = obj.UserName.ToString();
                //    return RedirectToAction("UserDashBoard");
                //}

                var obj =  _contex.UserProfiles.FirstOrDefault(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password));

                //var obj = _contex.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                if (obj != null)
                {
                    HttpContext.Session.SetString("UserID", obj.UserId.ToString());
                    HttpContext.Session.SetString("UserName", obj.UserName.ToString());
                    return RedirectToAction("Index");
                }

            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Logout logic
            return RedirectToAction("Login", "Home");
        }

    }
}