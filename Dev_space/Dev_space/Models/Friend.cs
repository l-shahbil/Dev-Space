using Dev_space.Models.AccountViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Friend
    {
        [Key]
        public string Id { get; set; }
        public string IdFriend { get; set; }

        //relationships
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

    }
}
