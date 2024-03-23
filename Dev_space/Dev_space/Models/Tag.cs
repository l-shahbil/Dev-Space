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
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}
