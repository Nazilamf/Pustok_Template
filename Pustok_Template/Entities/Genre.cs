using System.ComponentModel.DataAnnotations;

namespace Pustok_Template.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "20den uzun ola bilmez")]
        public string Name { get; set; }    
        public List<Book>Books { get; set; }
    }
}
