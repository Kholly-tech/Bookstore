using System.ComponentModel.DataAnnotations;

namespace Bookstore.Model
{
    public class LogInModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
