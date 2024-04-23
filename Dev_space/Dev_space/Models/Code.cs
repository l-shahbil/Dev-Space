using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Code
    {
        [Key]
        public int Id { get; set; }
        public string CodeText { get; set; } = string.Empty;

        //Relationships
        [ForeignKey("Post")]
        public int IdPost { get; set; }
        public Post? post { get; set; }
    }
}
