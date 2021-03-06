﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Basefarm.Demo.Web.Data;
using Basefarm.Demo.Web.Entities;

namespace Basefarm.Demo.Web.Pages.Disks
{
    public class EditModel : PageModel
    {
        private readonly Basefarm.Demo.Web.Data.DiskContext _context;

        public EditModel(Basefarm.Demo.Web.Data.DiskContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LogicalDisk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogicalDiskExists(LogicalDisk.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LogicalDiskExists(int id)
        {
            return _context.LogicalDisks.Any(e => e.Id == id);
        }
    }
}
