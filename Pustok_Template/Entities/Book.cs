using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pustok_Template.Entities
{
    public class Book
    {
        public int Id { get; set;}
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Desc { get; set; }
        public  int AuthorId { get; set; }
        public int GenreId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPercent { get; set; }
        public bool IsNew { get; set; } 
        public bool IsFeatured { get; set; }
        public bool StockStatus { get; set; }
        public Author Author { get; set; }

        public Genre Genre { get; set; }
        public List <BookTag> BookTags { get; set; }
        public List <BookImage> BookImages { get; set; }

      
            
        

    }
}
