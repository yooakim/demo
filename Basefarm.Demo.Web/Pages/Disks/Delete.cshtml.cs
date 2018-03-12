using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Basefarm.Demo.Web.Data;
using Basefarm.Demo.Web.Entities;

namespace Web.Pages.Disks
{
    public class DeleteModel : PageModel
    {
        private readonly Basefarm.Demo.Web.Data.DiskContext _context;

        public DeleteModel(Basefarm.Demo.Web.Data.DiskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LogicalDisk LogicalDisk { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LogicalDisk = await _context.LogicalDisks.SingleOrDefaultAsync(m => m.Id == id);

            if (LogicalDisk == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LogicalDisk = await _context.LogicalDisks.FindAsync(id);

            if (LogicalDisk != null)
            {
                _context.LogicalDisks.Remove(LogicalDisk);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
