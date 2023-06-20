using System.ComponentModel.DataAnnotations;

namespace Pustok_Template.Entities
{
    public class Features
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]

        public string Title { get; set; }
        [MaxLength(50)]
        public string Desc { get; set; }
        [Required]
        [MaxLength(50)]
        public string Icon { get; set; }
    }
}
