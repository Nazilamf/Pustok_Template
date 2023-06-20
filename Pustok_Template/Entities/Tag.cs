using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pustok_Template.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } 
        public List <BookTag> BookTags { get; set; }
    }
}
