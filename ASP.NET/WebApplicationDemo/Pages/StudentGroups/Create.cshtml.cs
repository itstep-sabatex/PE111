using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationDemo.Data;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Pages.StudentGroups
{
    public class CreateModel : PageModel
    {
        private readonly WebApplicationDemo.Data.ApplicationDbContext _context;

        public CreateModel(WebApplicationDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentGroup StudentGroup { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.StudentGroup == null || StudentGroup == null)
            {
                return Page();
            }

            _context.StudentGroup.Add(StudentGroup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
