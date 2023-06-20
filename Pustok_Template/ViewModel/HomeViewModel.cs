using Pustok_Template.Entities;

namespace Pustok_Template.ViewModel
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Features> Features { get; set; }
        public List<Book> FeaturedBooks { get; set; }
        public List<Book> NewBooks { get; set; }
        public List<Book> DiscountBooks { get; set; }
    }
}
