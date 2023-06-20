using System.ComponentModel.DataAnnotations;

namespace Pustok_Template.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Title1 { get; set; }
        public int Order { get; set; }
        [MaxLength(30)]
        public string Title2 { get; set; }
        [MaxLength(200)]
        public string Desc { get; set; }
        [MaxLength(10)]
        public string ButtonText { get; set; }
        [MaxLength(100)]
        public string ButtonUrl { get; set; }
        [Required]
        [MaxLength(100)]
        public string Image { get; set; }
     
    }
}
