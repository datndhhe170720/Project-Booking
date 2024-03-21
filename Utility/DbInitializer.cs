using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_PRN221_BookingFields.Data;

namespace Project_PRN221_BookingFields.Utility
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        //public DbInitializer( RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        //{
        //    //_userManager = userManager;
        //    _roleManager = roleManager;
        //    _context = context;
        //}
        public void Initialize()
        {
            try
            {
                if(_context.Database.GetPendingMigrations().Count() > 0)                    
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            if(!_roleManager.RoleExistsAsync(WebSiteRole.Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Customer)).GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Administrator",
                    Email = "admin@gmail.com",
                    FirstName = "Admin",
                    LastName = "Manager",
                }, "Admin@123");
                ApplicationUser user = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "admin@gmail.com");
                _userManager.AddToRoleAsync(user, WebSiteRole.Admin);
            }
        }
    }
}
