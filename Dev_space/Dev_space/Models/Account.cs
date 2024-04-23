using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FName { get; set; } = string.Empty;
        [Required]
        public string LName { get; set; } = string.Empty;
        [Required]
        public int gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Country { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateRegister { get; set; }=DateTime.Now;
        public string? ImgPath { get; set; }
        [NotMapped]
        public IFormFile PhotoProfile { get; set; }

        //RelationShip
        public ICollection<Friend> friends { get; set; }
        public ICollection<Post> posts { get; set; }
        public ICollection<Like> likes { get; set; }
        public ICollection<Commint> commints { get; set; }
        public ICollection<Link> links { get; set; }
        public ICollection<Tag> tags { get; set; }



    }
}
