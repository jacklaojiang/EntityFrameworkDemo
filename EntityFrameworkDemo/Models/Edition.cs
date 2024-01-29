using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkDemo.Models
{
    public class Edition
    {
        [Required]
        [Key]
        public string ISBN { get; set; }
        [ForeignKey("Book")]
        public string BookID { get; set; }
        
        public string Format { get; set; }
        public string PubID { get; set; }
        public string PublicationID { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Pages { get; set; }
        public int PrintRunSize { get; set; }
        public double Price { get; set; }
        public Book Book { get; set; }
    }
}
