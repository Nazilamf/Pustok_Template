using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol;
using Pustok_Template.DAL;
using Pustok_Template.Entities;
using Pustok_Template.ViewModel;

namespace Pustok_Template.Controllers
{
    public class BookController : Controller
    {

        private readonly PustokDbContext _context;

        public BookController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult GetDetail(int id)
        {
            Book book = _context.Books.Include(x => x.BookImages.Where(x => x.PosterStatus==true))
                .Include(x=>x.Author)
                .Include(x=>x.Genre)
                .Include(x => x.BookTags).ThenInclude(x => x.Tag)
                .FirstOrDefault(x => x.Id == id);
            return PartialView("_BookModalPartial",book);
            
        }

        public IActionResult AddtoBasket(int id) {
            var basketstr = Request.Cookies["basket"];
            List<BasketCookieItemsViewModel> Cookieitems = null;
            if (basketstr == null)
            {
               Cookieitems = new List<BasketCookieItemsViewModel>();
            }
            else
            {
               Cookieitems = JsonConvert.DeserializeObject<List<BasketCookieItemsViewModel>>(basketstr);
            }
            BasketCookieItemsViewModel cookieitem = Cookieitems.FirstOrDefault(x => x.BookId == id);
                if (cookieitem == null)
            {
                cookieitem = new BasketCookieItemsViewModel
            {
                BookId= id,
                Count= 1
            };
                Cookieitems.Add(cookieitem);
            }
            else
            {
                cookieitem.Count++;
            }

            
            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(Cookieitems));
            BasketViewModel basketVM = new BasketViewModel();
            foreach (var ci in Cookieitems)
            {
                BasketItemViewModel item = new BasketItemViewModel()
                {
                    Count = ci.Count,
                    Book = _context.Books.Include(x => x.BookImages.Where(x => x.PosterStatus== true)).FirstOrDefault(x => x.Id == ci.BookId)

                };
                basketVM.Items.Add(item);
                basketVM.TotalPrice += (item.Book.DiscountPercent > 0 ? item.Book.SalePrice * (100 - item.Book.DiscountPercent) / 100 : item.Book.SalePrice) * item.Count;

            }

            return PartialView("_BasketPartial", basketVM);
        }

        public IActionResult ShowBasket() {
           var datastr = HttpContext.Request.Cookies["basket"];
            var data = JsonConvert.DeserializeObject<List<BasketCookieItemsViewModel>>(datastr);
            return Json(data);
        }
    }
}
