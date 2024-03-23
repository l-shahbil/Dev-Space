using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }= DateTime.Now;

        //Relationships
        [ForeignKey("Account")]
        public int IdAccount { get; set; }
        public Account? account { get; set; }



        [ForeignKey("Post")]
        public int IdPost { get; set; }
        public Post? post { get; set; }

    }
}
