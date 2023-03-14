using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_Kizy.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem (Book book, int qty, decimal price)
        {
            BasketLineItem Line = Items
                .Where(b => b.Books.BookId == book.BookId)
                .FirstOrDefault();


            if(Line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = book,
                    Quantity = qty,
                    //Price = price,


                });
            }
            else
            {
                Line.Quantity += qty; /*line.Quantity + qty*/
            }
        }

        //public double CalculateTotal()
        //{
        //    double sum = (double)Items.Sum(x => x.Quantity * x.Price);

        //    return sum;
        //}
    }

    
    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Books { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
