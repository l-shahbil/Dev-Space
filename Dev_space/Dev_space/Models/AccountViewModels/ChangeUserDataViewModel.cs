using Dev_space.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models.AccountViewModels
{
    public class ChangeUserDataViewModel
    {  
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RegisterName")]
        [MaxLength(20, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MinLength")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "UserName")]
        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RigsterUserNameError")] public string UserName { get; set; }
        [MinLength(3, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MinUserName")]

        public string userName { get; set; }
        public string? Discription { get; set; }
        public string? LinkTwitter { get; set; }
        public string? LinkInstagram { get; set; }
        public string? LinkBehance { get; set; }
        public string? LinkGithub { get; set; } 
        public IFormFile? ImgProfile { get; set; }
        public IFormFile? ImgCover { get; set; }
    }
}
