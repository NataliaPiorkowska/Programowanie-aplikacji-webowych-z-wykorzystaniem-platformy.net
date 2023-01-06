using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesProject.Data;
using RazorPagesProject.Models;

namespace RazorPagesProject.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesProject.Data.RazorPagesProjectContext _context;

        public DetailsModel(RazorPagesProject.Data.RazorPagesProjectContext context)
        {
            _context = context;
        }

      public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }
            else 
            {
                Project = project;
            }
            return Page();
        }
    }
}
