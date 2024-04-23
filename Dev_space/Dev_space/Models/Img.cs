using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Img
    {
        [Key]
        public int Id { get; set; }
        public string? pathImg { get; set; }
        [NotMapped]
        public IFormFile img { get; set; }

        //Relationships
        [ForeignKey("Post")]
        public int IdPost { get; set; }
        public Post? post { get; set; }
    }
}
