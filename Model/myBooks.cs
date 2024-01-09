using System.ComponentModel.DataAnnotations;

namespace Bookstore.Model
{
	public class myBooks
	{
		[Key]
        public int Id { get; set; }

		[Required(ErrorMessage ="The BookTitle Field cannot be empty...")]
		public string BookTitle { get; set; }

		[Required]
		public string AuthorName { get; set; }

		[Required]
		[MinLength(20, ErrorMessage ="The Description of Book must exceed 20 characters")]
		public string BookDescription { get; set; }

		[Required]
		public double BookPrice { get; set; }

		[Required]
		[Range(0,10000000)]
        public int Pages { get; set; }
        public string BookPic { get; set; }
    }
}
