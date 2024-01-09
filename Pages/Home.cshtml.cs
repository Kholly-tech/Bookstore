using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
	[Authorize]
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
            //if (!User.Identity.IsAuthenticated)
            //{
            //    // Redirect to the login page
            //    return RedirectToPage("Index", new { area = "Identity" });
            //}

            //// Code for handling GET requests for authenticated users
            //return Page();
        }
	}
}