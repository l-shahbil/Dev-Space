using Dev_space.Resources;
using System.ComponentModel.DataAnnotations;

namespace Dev_space.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "Password")]
        public string Password { get; set; }
        public bool RemmeberMe { get; set; }
    }
}
