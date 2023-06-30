using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Data;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Pages.StudentGroups
{
    public class EditModel : PageModel
    {
        private readonly WebApplicationDemo.Data.ApplicationDbContext _context;

        public EditModel(WebApplicationDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentGroup StudentGroup { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudentGroup == null)
            {
                return NotFound();
            }

            var studentgroup =  await _context.StudentGroup.FirstOrDefaultAsync(m => m.Id == id);
            if (studentgroup == null)
            {
                return NotFound();
            }
            StudentGroup = studentgroup;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentGroupExists(StudentGroup.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentGroupExists(int id)
        {
          return (_context.StudentGroup?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
