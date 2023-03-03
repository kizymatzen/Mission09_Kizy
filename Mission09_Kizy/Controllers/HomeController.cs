using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission09_Kizy.Models;


namespace Mission09_Kizy.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;

            var book = repo.Books
                .OrderBy(p => p.Author)
                .Skip((pageNum -1) * pageSize)
                .Take(pageSize);

            return View(book);
        }
    }
}
