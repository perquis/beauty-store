using Microsoft.AspNetCore.Identity;

namespace BeautyStore.Infrastructure.Seeders
{
    public class SuperUsersSeeder
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SuperUsersSeeder(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed(string password)
        {
            var user = await _userManager.FindByEmailAsync("admin@gmail.com");

            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                };

                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
