using Dev_space.Models.AccountViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Commint
    {
        [Key]
        public string Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        //Relationships
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }



        [ForeignKey("PostID")]
        public Post? post { get; set; }
    }
}
