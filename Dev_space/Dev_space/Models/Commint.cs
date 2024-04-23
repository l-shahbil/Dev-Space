using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Commint
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        //Relationships
        [ForeignKey("Account")]
        public int IdAccount { get; set; }
        public Account? account { get; set; }



        [ForeignKey("Post")]
        public int IdPost { get; set; }
        public Post? post { get; set; }
    }
}
