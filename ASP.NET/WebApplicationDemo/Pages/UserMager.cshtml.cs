using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplicationDemo.Data;

namespace WebApplicationDemo.Pages
{
    public class UserMagerModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        

        public IdentityUser[] IdentityUsers { get; set; }
        public Dictionary<string,string> UserRoles { get; set; }= new Dictionary<string,string>();
        public UserMagerModel(ApplicationDbContext dbContext)
        {
            _context = dbContext;       
        }
        public async Task OnGetAsync()
        {
            IdentityUsers = await _context.Users.ToArrayAsync();
            foreach (var user in IdentityUsers)
            {
                var userRoles = await _context.UserRoles.Where(s=>s.UserId == user.Id).ToArrayAsync();
                string userRole = string.Empty;
                foreach(var role in userRoles)
                {
                    var s = await _context.Roles.FindAsync(role.RoleId);
                    userRole = userRole + s.Name + ";";
                }
                UserRoles.Add(user.Id, userRole); //string.Join(';',)
            }

        }
    }
}
