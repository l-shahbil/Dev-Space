using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Img
    {
        [Key]
        public string Id { get; set; }
        public string pathImg { get; set; }

        //Relationships
        [ForeignKey("PostID")]
        [Required]
        public Post? post { get; set; }
    }
}
