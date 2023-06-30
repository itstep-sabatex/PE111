using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Data;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Pages.StudentGroups
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplicationDemo.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplicationDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public StudentGroup StudentGroup { get; set; } = default!;
        public IList<Student> Student { get; set; } = default!;
        [BindProperty]
        public string SearchName { get; set; }
        [BindProperty]
        public string SearchDirection { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudentGroup == null)
            {
                return NotFound();
            }

            var studentgroup = await _context.StudentGroup.FirstOrDefaultAsync(m => m.Id == id);
            if (studentgroup == null)
            {
                return NotFound();
            }
            else 
            {
                StudentGroup = studentgroup;
            }

            if (_context.Students != null)
            {
                Student = await _context.Students
                .Where(s=>StudentGroup.Id == s.StudentGroupId).ToListAsync();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostFilterAsync(int? id)
        {
            if (id == null || _context.StudentGroup == null)
            {
                return NotFound();
            }

            var studentgroup = await _context.StudentGroup.FirstOrDefaultAsync(m => m.Id == id);
            if (studentgroup == null)
            {
                return NotFound();
            }
            else
            {
                StudentGroup = studentgroup;
            }

            var result = _context.Students.Where(w=>w.StudentGroupId==StudentGroup.Id);
            if (!string.IsNullOrEmpty(SearchName))
            {
                switch (SearchDirection)
                {
                    case "Contains":
                        result = result.Where(s => s.Name.Contains(SearchName) || s.Surname.Contains(SearchName));
                        break;
                    case "StartWith":
                        result = result.Where(s => s.Name.StartsWith(SearchName) || s.Surname.StartsWith(SearchName));
                        break;
                    case "EndWith":
                        result = result.Where(s => s.Name.EndsWith(SearchName) || s.Surname.EndsWith(SearchName));
                        break;

                }
            }
            Student = await result.ToListAsync();
            return Page();
        }


    }
}
