using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_Template.ViewModel
{
    public class BasketViewModel
    {
        public List<BasketItemViewModel> Items { get; set; } = new List<BasketItemViewModel>();
        [Column(TypeName = "decimal(8,2)")]
        public decimal TotalPrice { get; set; }
    }
}
