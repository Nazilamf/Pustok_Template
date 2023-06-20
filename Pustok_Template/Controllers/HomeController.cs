using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Template.DAL;
using Pustok_Template.ViewModel;

namespace Pustok_Template.Controllers
{
    public class HomeController : Controller
    {
        private readonly PustokDbContext _context;
        public HomeController(PustokDbContext context)
        {
            _context= context;

        }

        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel()
            {
                Sliders= _context.Sliders.OrderBy(x => x.Order).ToList(),
                Features = _context.Features.Take(4).ToList(),
                FeaturedBooks = _context.Books.
                Include(x=>x.Author).Include(x=>x.BookImages.Where(x=>x.PosterStatus!=null))
                .Where(x => x.IsFeatured).Take(20).ToList(),
                NewBooks = _context.Books.
                Include(x => x.Author).Include(x => x.BookImages.Where(x => x.PosterStatus!=null))
                .Where(x => x.IsNew).Take(20).ToList(),
                DiscountBooks =_context.Books.
                Include(x => x.Author).Include(x => x.BookImages.Where(x => x.PosterStatus!=null))
                .Where(x => x.DiscountPercent>0).Take(20).ToList(),

            };
            return View(vm);
        }
    }
}
