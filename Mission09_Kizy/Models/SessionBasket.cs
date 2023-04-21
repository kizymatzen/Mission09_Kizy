using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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
        public SessionBasket() { }

        // Add a new constructor that takes in session and bookstoreRepository
        public SessionBasket(ISession session, IBookstoreRepository bookstoreRepository)
        {
            Session = session;
            _bookstoreRepository = bookstoreRepository;
        }

        private readonly IBookstoreRepository _bookstoreRepository;

        public static Basket GetBasket(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            // Inject IBookstoreRepository into the SessionBasket constructor
            var bookstoreRepository = services.GetRequiredService<IBookstoreRepository>();

            var basket = session.GetJson<Basket>("Basket") ?? new Basket();
            // Pass session and bookstoreRepository to the SessionBasket constructor
            var sessionBasket = new SessionBasket(session, bookstoreRepository);
            sessionBasket.Items = basket.Items;
            return sessionBasket;
        }

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
