using System.ComponentModel.DataAnnotations;

namespace Bookstore.Model
{
    public class BookCreateViewModel
    {
        //[Key]
        //public int Id { get; set; }

        [Required]
        public string BookTitle { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string BookDescription { get; set; }

        [Required]
        public double BookPrice { get; set; }

        public int Pages { get; set; }
        public IFormFile BookPhoto { get; set; }
    }
}
