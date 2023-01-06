using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RazorPagesProject.Data;

namespace RazorPagesProject.Models
{
    public static class SeedData
    {
        public static async Task InitializeAsync(
            IServiceProvider serviceProvider,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            using (var context = new RazorPagesProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesProjectContext>>()))
            {
                if (context == null || context.Project == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                if (roleManager.FindByNameAsync("Admin").Result == null)
                {
                    var role = new IdentityRole()
                    {
                        Name = "Admin",
                    };

                    var res = await roleManager.CreateAsync(role);
                }

                if (await userManager.FindByNameAsync("admin@admin.pl") == null)
                {
                    var user = new IdentityUser()
                    {
                        UserName= "admin@admin.pl",
                        Email= "admin@admin.pl"

                    };
                    var result = await userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        await userManager.AddPasswordAsync(user, "Admin!23");
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                }


                // Look for any movies.
                if (context.Project.Any())
                {
                    return;   // DB has been seeded
                }

                context.Project.AddRange(
                    new Project
                    {
                        Name = "Roche - FullStack Developer - B2B",
                        CreationDate = DateTime.Parse("2023-1-5"),
                        Client = "Roche",
                        Price = 160.00M,
                        Country="Poland"
                    },

                    new Project
                    {
                        Name = "Rockwell - Scrum Master - B2B",
                        CreationDate = DateTime.Parse("2022-3-13"),
                        Client = "Rockwell",
                        Price = 200.00M,
                        Country = "Poland"
                    },

                    new Project
                    {
                        Name = "Orlen - Project Manager - UoP",
                        CreationDate = DateTime.Parse("2023-1-1"),
                        Client = "Orlen",
                        Price = 50.00M,
                        Country = "Poland"
                    },

                    new Project
                    {
                        Name = "Orlen - Data Analyst - B2B",
                        CreationDate = DateTime.Parse("2022-12-12"),
                        Client = "Orlen",
                        Price = 110.00M,
                        Country = "Deutchland"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
