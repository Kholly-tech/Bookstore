using Bookstore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;


namespace Bookstore.Pages.Books
{
    //[Authorize]
    public class AddBookModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;

        public AddBookModel(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]

        public myBooks Books { get; set; }
        public BookCreateViewModel BookCreate {  get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var imagePath = "www/img" + BookCreate.BookPhoto.FileName;

                using(var stream=new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, imagePath), FileMode.Create))
                {
                    await BookCreate.BookPhoto.CopyToAsync(stream);
                }

                var formsubmission = new myBooks
                {
                    
                    BookTitle = BookCreate.BookTitle,
                    AuthorName = BookCreate.AuthorName,
                    BookDescription = BookCreate.BookDescription,
                    BookPrice = BookCreate.BookPrice,
                    Pages = BookCreate.Pages,
                    BookPic = imagePath
                };

                await _db.myBooks.AddAsync(formsubmission);
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "You have Successfuklly added " + BookCreate.BookTitle + " to the database";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
