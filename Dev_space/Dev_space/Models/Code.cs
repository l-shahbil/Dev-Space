using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Code
    {
        [Key]
        public string Id { get; set; }
        public string CodeText { get; set; } = string.Empty;

        //Relationships
        [ForeignKey("PostID")]
        [Required]
        public Post? post { get; set; }
    }
}
