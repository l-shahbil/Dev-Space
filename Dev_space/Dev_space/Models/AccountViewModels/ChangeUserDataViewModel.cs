using Dev_space.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models.AccountViewModels
{
    public class ChangeUserDataViewModel
    {  
        public string Id { get; set; }
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RigsterUserNameError")]
        public string UserName { get; set; }
        public string Discription { get; set; }
        public string LinkTwitter { get; set; }
        public string LinkInstagram { get; set; }
        public string LinkBehance { get; set; }
        public string LinkGithub { get; set; }
        public IFormFile ImgProfile { get; set; }
        public IFormFile ImgCover { get; set; }
    }
}
