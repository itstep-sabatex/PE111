using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty(SupportsGet =true)]
        public string Student { get; set; }
        public async Task OnGetAsync()
        {
            var a = 10;
            //Student = "Petrenco Ivan";
        }

        public void OnPostSave() { }

        public void OnPost()
        {
        }
    }
}