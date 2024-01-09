using Bookstore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Pages.Books
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db= db;
        }

        public IEnumerable<myBooks> Books;

        public async Task OnGet()
        {

			Books = await _db.myBooks.ToListAsync();
        }

        //[Authorize]
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var delBook = await _db.myBooks.FindAsync(id);
            if (delBook != null)
            {
                _db.myBooks.Remove(delBook);
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
