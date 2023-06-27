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

        public async Task OnPostFilterAsync(string searchName,string searchDirection)
        {
            var result = _context.StudentGroup.AsQueryable();
            if (!string.IsNullOrEmpty(searchName))
            {
                switch (searchDirection)
                {
                    case "Contains":
                        result = result.Where(s => s.Name.Contains(searchName));
                        break;
                    case "StartWith":
                        result = result.Where(s => s.Name.StartsWith(searchName));
                        break;
                    case "EndWith":
                        result = result.Where(s => s.Name.EndsWith(searchName));
                        break;

                }
            }
            StudentGroup = await result.ToListAsync();
        }
    }


}
