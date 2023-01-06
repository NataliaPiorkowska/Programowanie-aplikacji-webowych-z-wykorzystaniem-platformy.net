using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPagesProject.Models;

namespace RazorPagesProject.Data
{
    public class RazorPagesProjectContext : IdentityDbContext
    {
        public RazorPagesProjectContext (DbContextOptions<RazorPagesProjectContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesProject.Models.Project> Project { get; set; } = default!;
    }
}
