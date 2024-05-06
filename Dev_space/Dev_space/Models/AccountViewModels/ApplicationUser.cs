using Microsoft.AspNetCore.Identity;

namespace Dev_space.Models.AccountViewModels
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string ImgUser { get; set; }
        public string CoverImgUser { get; set; }
         public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public DateTime DateRegister { get; set; }
        public bool ActiveUser { get; set; }

        //RelationShip
        public ICollection<Friend> friends { get; set; }
        public ICollection<Post> posts { get; set; }
        public ICollection<Like> likes { get; set; }
        public ICollection<Commint> commints { get; set; }
        public ICollection<Link> links { get; set; }
        public ICollection<Tag> tags { get; set; }
        public ICollection<Archive> archives { get; set; }
    }
}
