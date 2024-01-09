using Bookstore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class RegisterModel : PageModel
    {
        
        private ApplicationDbContext _db;

        public RegisterModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Users users { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Users.AddAsync(users);
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "You have successfully created a user account. Please, Log In.";
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }
        }
    }
}
