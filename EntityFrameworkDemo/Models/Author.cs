using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.Models
{
    public class Author
    {
        [Required]
        [Key]
        public string AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string CountryOfResidence { get; set; }
        public int HrsWritingPerDay { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
