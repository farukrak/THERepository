using AloeExpress.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data
{
    public class RoleInitializer
    {
        public static async Task InitializerAsync(UserManager<Provider> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@admin.com";
            string password = "Aa!2345";

            string userEmail = "user@user.com";
            string userPassword = "Aa!2345";


            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.CreateAsync(new IdentityRole("user")) == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                Provider admin = new()
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    FirstName = "admin",
                    LastName = "admin",
                };

                Provider user = new()
                {
                    Email = userEmail,
                    UserName = userEmail,
                    FirstName = "user",
                    LastName = "user",
                };

                var result = await userManager.CreateAsync(admin, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }

                result = await userManager.CreateAsync(user, userPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }
        }
    }
}
