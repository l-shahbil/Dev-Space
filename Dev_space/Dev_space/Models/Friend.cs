using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }
        public int IdFriend { get; set; }

        //relationships
        [ForeignKey("Account")]
        public int IdAccount { get; set;}
        public Account account { get; set; }

    }
}
