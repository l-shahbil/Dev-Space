using Dev_space.Models.AccountViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; }= DateTime.Now;

        //relationships
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public ICollection<Code> Codes { get; set; }
        public ICollection<Img> Imgs { get; set; }
        public ICollection<Like> likes { get; set; }
        public ICollection<Commint> commints { get; set; }
        public ICollection<Tag> tags { get; set; }


    }
}
