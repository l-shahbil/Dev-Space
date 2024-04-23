using Dev_space.Models.AccountViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Like
    {
        [Key]
        public string Id { get; set; }
        public DateTime DateTime { get; set; }= DateTime.Now;

        //Relationships
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }



        [ForeignKey("PostID")]
        public Post? post { get; set; }

    }
}
