using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Data;

namespace WebApplicationDemo
{
    public class Program
    {


        static async Task initialAutorized(IServiceProvider host)
        {
            using (var serviceScope =host.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var RoleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var UserManager = services.GetRequiredService<UserManager<IdentityUser>>();
                var  _userStore = services.GetRequiredService<IUserStore<IdentityUser>>();
                var  _emailStore = (IUserEmailStore<IdentityUser>)_userStore;
                var adminRole = await RoleManager.FindByNameAsync("Administrator");
                const string adminUser = "www@were.ty";
                const string adminPass = "aq1SW2de3fr4-";
                if (adminRole == null)
                {
                    var adminR = await RoleManager.CreateAsync(new IdentityRole("Administrator"));
                    if (adminR.Succeeded == false) { throw new Exception("Error create role "); }
                    adminRole = await RoleManager.FindByNameAsync("Administrator");
                }
                var userAdmin = await UserManager.FindByNameAsync(adminUser);
                if (userAdmin == null)
                {
                    var user = Activator.CreateInstance<IdentityUser>();
                    await _userStore.SetUserNameAsync(user, adminUser, CancellationToken.None);
                    await _emailStore.SetEmailAsync(user, adminUser, CancellationToken.None);
                    var result = await UserManager.CreateAsync(user, adminPass);
                    if (result.Succeeded)
                    {
                    
                        var userId = await UserManager.GetUserIdAsync(user);
                        var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                        var resultConfirm = await UserManager.ConfirmEmailAsync(user, code);
                        userAdmin = await UserManager.FindByNameAsync(adminUser);

                    }
                    else
                    { throw new Exception(); }
                }

                if (!await UserManager.IsInRoleAsync(userAdmin, "Administrator"))
                {
                    await UserManager.AddToRoleAsync(userAdmin, "Administrator");
                }


            }

        }


        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.Use(async (context, next) =>
            {
                // Do work that can write to the Response.

                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
            });


            await initialAutorized(app.Services);
            app.Run();
        }
    }
}