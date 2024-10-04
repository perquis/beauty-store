using Microsoft.AspNetCore.Identity;

namespace BeautyStore.Infrastructure.Seeders
{
	public class UserRolesSeeder
	{
		private readonly RoleManager<IdentityRole> _roleManager;

		public UserRolesSeeder(RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public async Task Seed()
		{
			if (!await _roleManager.RoleExistsAsync("Admin"))
			{
				await _roleManager.CreateAsync(new IdentityRole("Admin"));
			}

			if (!await _roleManager.RoleExistsAsync("User"))
			{
				await _roleManager.CreateAsync(new IdentityRole("User"));
			}
		}
	}
}
