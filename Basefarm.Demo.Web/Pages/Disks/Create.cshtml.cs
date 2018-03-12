using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Basefarm.Demo.Web.Data;
using Basefarm.Demo.Web.Entities;

namespace Web.Pages.Disks
{
    public class CreateModel : PageModel
    {
        private readonly Basefarm.Demo.Web.Data.DiskContext _context;

        public CreateModel(Basefarm.Demo.Web.Data.DiskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LogicalDisk LogicalDisk { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LogicalDisks.Add(LogicalDisk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}