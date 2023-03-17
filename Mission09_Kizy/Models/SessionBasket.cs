using Microsoft.AspNetCore.Http;
using Mission09_Kizy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission09_Kizy.Models
{
    public class SessionBasket : Basket
    {
        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book book, int qty, Book price)
        {
            base.AddItem(book, qty, price);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }

    }
}
