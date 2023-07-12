using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Data;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Pages.StudentGroups
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        private readonly WebApplicationDemo.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public IndexModel(WebApplicationDemo.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager; 
        }

        public IList<StudentGroup> StudentGroup { get;set; } = default!;
        [BindProperty]
        public string SearchName { get; set; }
        [BindProperty]
        public string SearchDirection { get; set; }
        [BindProperty]
        public int Page { get; set; }
        public async Task OnGetAsync()
        {

            if (_context.StudentGroup != null)
            {
                StudentGroup = await _context.StudentGroup.Skip(Page*5).Take(5).ToListAsync();
            }
        }

        public async Task OnPostFilterAsync()
        {
            var result = _context.StudentGroup.AsQueryable();
            if (!string.IsNullOrEmpty(SearchName))
            {
                switch (SearchDirection)
                {
                    case "Contains":
                        result = result.Where(s => s.Name.Contains(SearchName));
                        break;
                    case "StartWith":
                        result = result.Where(s => s.Name.StartsWith(SearchName));
                        break;
                    case "EndWith":
                        result = result.Where(s => s.Name.EndsWith(SearchName));
                        break;

                }
            }
            StudentGroup = await result.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null || _context.StudentGroup == null)
            {
                return NotFound();
            }
            var studentgroup = await _context.StudentGroup.FindAsync(id);

            var user = await _userManager.GetUserAsync(User);
            if (!await _userManager.IsInRoleAsync(user, "Adminisrator"))
            {
                return Unauthorized();
            }

            if (studentgroup != null)
            {
                 _context.StudentGroup.Remove(studentgroup);
                await _context.SaveChangesAsync();
            }
            StudentGroup = await _context.StudentGroup.Skip(Page * 5).Take(5).ToListAsync();
            return Page();
        }

    }


}
