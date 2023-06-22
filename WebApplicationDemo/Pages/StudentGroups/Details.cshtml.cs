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
            return Page();
        }
    }
}
