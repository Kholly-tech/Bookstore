using Bookstore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Pages.Books
{
    [Authorize]
    public class EditDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditDetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public myBooks Books { get; set; }
        public IEnumerable<myBooks> Books2 { get; set; }

        [AllowAnonymous]
        public async Task OnGet(int id)
        {

            Books = await _db.myBooks.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var getBook= await _db.myBooks.FindAsync(Books.Id);
                getBook.BookTitle = Books.BookTitle;
                getBook.AuthorName = Books.AuthorName;
                getBook.BookDescription = Books.BookDescription;
                getBook.BookPrice = Books.BookPrice;
                getBook.Pages = Books.Pages;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
