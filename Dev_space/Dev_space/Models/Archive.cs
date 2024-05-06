using Dev_space.Models.AccountViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Archive
    {
        public string Id { get; set; }
        public DateTime dateAdded { get; set; }

        //relationships
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [ForeignKey("PostID")]
        [Required]
        public Post Post { get; set; }


    }
}
