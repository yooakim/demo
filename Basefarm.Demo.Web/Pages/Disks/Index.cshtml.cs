using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Basefarm.Demo.Web.Data;
using Basefarm.Demo.Web.Entities;

namespace Basefarm.Demo.Web.Pages.Disks
{
    public class IndexModel : PageModel
    {
        private readonly Basefarm.Demo.Web.Data.DiskContext _context;

        public IndexModel(Basefarm.Demo.Web.Data.DiskContext context)
        {
            _context = context;
        }

        public IList<LogicalDisk> LogicalDisk { get;set; }

        public async Task OnGetAsync()
        {
            LogicalDisk = await _context.LogicalDisks.ToListAsync();
        }
    }
}
