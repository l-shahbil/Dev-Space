using Dev_space.Models.AccountViewModels;
using System.ComponentModel.DataAnnotations;

namespace Dev_space.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;

        //relationship
        public ICollection<ApplicationUser> User { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}
