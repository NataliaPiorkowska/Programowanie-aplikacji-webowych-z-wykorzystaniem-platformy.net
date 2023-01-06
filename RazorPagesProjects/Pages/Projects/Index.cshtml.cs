using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesProject.Data;
using RazorPagesProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesProject.Pages.Projects
{

    public class IndexModel : PageModel
    {
        private readonly RazorPagesProject.Data.RazorPagesProjectContext _context;

        public IndexModel(RazorPagesProject.Data.RazorPagesProjectContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Clients { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ProjectGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Project
                                            orderby m.Client
                                            select m.Client;

            var projects = from m in _context.Project
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                projects = projects.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ProjectGenre))
            {
                projects = projects.Where(x => x.Client == ProjectGenre);
            }
            Clients = new SelectList(await genreQuery.Distinct().ToListAsync());
            Project = await projects.ToListAsync();
        }
    }
}
