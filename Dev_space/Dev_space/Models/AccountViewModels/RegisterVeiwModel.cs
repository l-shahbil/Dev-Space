using Dev_space.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models.AccountViewModels
{
    public class RegisterVeiwModel
    {
        public List<ApplicationUser> Users { get; set; }
        public NewRegister NewRegister { get; set; }
        public ChangePasswordViewModel ChangePassword { get; set; }
        public ChangeUserDataViewModel ChangeUserData { get; set; }
    }
    public class NewRegister
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RegisterName")]
        [MaxLength(20, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MaxLength")]
        [MinLength(3, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MinLength")]
        public string Name { get; set; }
        [Required (ErrorMessageResourceType = typeof(ResourceData),ErrorMessageResourceName = "UserName")]
        [RegularExpression(@"^[a-zA-Z0-9_]*$",ErrorMessageResourceType = typeof (ResourceData), ErrorMessageResourceName ="RigsterUserNameError")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "roleName")]
        public string RoleName { get; set; } = "User";
        [Required (ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RegisterEmail")]
        [EmailAddress(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RegisterEmailError")]
        public string Email { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData),ErrorMessageResourceName = "RegisterGender")]
        public string gender { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RegisterBirthDate")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RegisterCountry")]
        public string Country { get; set; }
        public string ImageUser { get; set; }
        public bool ActiveUser { get; set; }
        [MaxLength(20, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MaxLength")]
        [MinLength(5, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MinLengthPassword")]
        public string Password { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "ComparePassword")]
        [Compare("Password", ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "ComparePasswordError")]
        public string ComparePassword { get; set; }
        public string Description { get; set; }
        public DateTime DateRegister { get; set; }
        


    }

}

