using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_Kizy.Models.ViewModels
{
    public class BooksViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string PageAction { get; set; }
        public Dictionary<int, int> BooksInCart { get; set; }

        // Constructor to initialize BooksInCart property
        public BooksViewModel()
        {
            BooksInCart = new Dictionary<int, int>();
        }
    }

}
