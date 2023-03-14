using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_Kizy.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Book book, int qty, Book price)
        {
            BasketLineItem line = Items.FirstOrDefault(b => b.Books.BookId == book.BookId);

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = book,
                    Quantity = qty,
                    Price = price
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public decimal CalculateSubtotal()
        {
            decimal sum = (decimal)Items.Sum(x => x.Quantity * x.Books.Price);
            return sum;
        }

        public decimal CalculateTotal()
        {
            decimal subtotal = CalculateSubtotal();
            decimal total = subtotal + (decimal)(subtotal * 0.1m); // assuming 10% tax

            return total;
        }
    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Books { get; set; }
        public int Quantity { get; set; }
        public Book Price { get; set; }
    }
}
