using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_Kizy.Models;

namespace Mission09_Kizy.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public ShoppingCartModel (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public void OnGet(Basket b)
        {
            basket = b;
        }

        public IActionResult OnPost(int bookId)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket = new Basket();
            basket.AddItem(b, 1);

            return RedirectToPage(basket);
        }
    }
}
