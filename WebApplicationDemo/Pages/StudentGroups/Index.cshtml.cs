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
    public class IndexModel : PageModel
    {
        private readonly WebApplicationDemo.Data.ApplicationDbContext _context;

        public IndexModel(WebApplicationDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<StudentGroup> StudentGroup { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.StudentGroup != null)
            {
                StudentGroup = await _context.StudentGroup.ToListAsync();
            }
        }
    }
}
