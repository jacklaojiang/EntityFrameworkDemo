using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo.Models
{
    public class Book
    {
        [Required]
        [Key]
        public string BookID { get; set; }
        [ForeignKey("Author")]
        public string AuthID { get; set; }
        public string Title { get; set; }

        public Author Author { get; set; }
        public ICollection<Edition> Editions { get; set; }
    }
}
