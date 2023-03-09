using Microsoft.AspNetCore.Mvc;
using Mission09_Kizy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_Kizy.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookstoreRepository reposi { get; set; }

        public CategoriesViewComponent (IBookstoreRepository temp)
        {
            reposi = temp;
        }

        public IViewComponentResult Invoke()
        {
            var category = reposi.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);


            return View(category);
        }
    }
}
