using Microsoft.AspNetCore.Http;
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
            Session.SetJsson()
        }
}
