using Dev_space.Models.AccountViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Link
    {
        [Key]
        public string Id { get; set; }
        public string URL { get; set; } = string.Empty;
        public int Type { get; set; }

        //Relationships
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
