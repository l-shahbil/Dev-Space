using Dev_space.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Friend
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }
        public string IdFriend { get; set; }
        public DateTime DateFollow { get; set; }
        //relationships
        public ApplicationUser User { get; set; }

    }
}
