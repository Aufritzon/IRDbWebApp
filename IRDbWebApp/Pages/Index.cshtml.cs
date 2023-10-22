using IRDbWebApp.Api;
using IRDbWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IRDbWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public MovieModel? NewMovie { get; set; }
        public IEnumerable<MovieModel>? Movies { get; set; }
        private readonly ApiCaller apiCaller = new ApiCaller();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            Movies = await apiCaller.GetMovies();
        }

        // Handle the form submission
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If the form is not valid, return the page with errors
                return Page();
            }

            await apiCaller.AddMovie(NewMovie);

            // Add code here to save the NewMovie data to your data source
            // For example, if you're using a database, you would add the new movie record

            // Redirect to the page or another page after adding the movie
            return RedirectToPage("Index");
        }
    }
}