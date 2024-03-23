using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Archive
    {
        [Key]
        public int Id { get; set; }
        //relationships
        [ForeignKey("Account")]
        public int IdAccount { get; set; }
        [ForeignKey("Post")]
        public int IdPost { get; set; }


    }
}
