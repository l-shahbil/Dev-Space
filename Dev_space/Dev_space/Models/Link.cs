using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev_space.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string URL { get; set; } = string.Empty;
        public int Type { get; set; }

        //Relationships
        [ForeignKey("Account")]
        public int IdAccount { get; set; }
        public Account? account { get; set; }
    }
}
