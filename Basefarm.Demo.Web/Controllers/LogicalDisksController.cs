using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Basefarm.Demo.Web.Data;
using Basefarm.Demo.Web.Entities;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/LogicalDisks")]
    public class LogicalDisksController : Controller
    {
        private readonly DiskContext _context;

        public LogicalDisksController(DiskContext context)
        {
            _context = context;
        }

        // GET: api/LogicalDisks
        [HttpGet]
        public IEnumerable<LogicalDisk> GetLogicalDisks()
        {
            return _context.LogicalDisks;
        }

        // GET: api/LogicalDisks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogicalDisk([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var logicalDisk = await _context.LogicalDisks.SingleOrDefaultAsync(m => m.Id == id);

            if (logicalDisk == null)
            {
                return NotFound();
            }

            return Ok(logicalDisk);
        }

        // PUT: api/LogicalDisks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogicalDisk([FromRoute] int id, [FromBody] LogicalDisk logicalDisk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logicalDisk.Id)
            {
                return BadRequest();
            }

            _context.Entry(logicalDisk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogicalDiskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LogicalDisks
        [HttpPost]
        public async Task<IActionResult> PostLogicalDisk([FromBody] LogicalDisk logicalDisk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LogicalDisks.Add(logicalDisk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogicalDisk", new { id = logicalDisk.Id }, logicalDisk);
        }

        // DELETE: api/LogicalDisks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogicalDisk([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var logicalDisk = await _context.LogicalDisks.SingleOrDefaultAsync(m => m.Id == id);
            if (logicalDisk == null)
            {
                return NotFound();
            }

            _context.LogicalDisks.Remove(logicalDisk);
            await _context.SaveChangesAsync();

            return Ok(logicalDisk);
        }

        private bool LogicalDiskExists(int id)
        {
            return _context.LogicalDisks.Any(e => e.Id == id);
        }
    }
}