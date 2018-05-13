using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Basefarm.Demo.Web.Data;
using Basefarm.Demo.Web.Entities;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Drives")]
    public class DrivesController : Controller
    {
        private readonly DiskContext _context;

        public DrivesController(DiskContext context)
        {
            _context = context;
        }

        // GET: api/Drives
        [HttpGet]
        public IEnumerable<PSDrive> GetPSDrives()
        {
            return _context.PSDrives;
        }

        // GET: api/Drives/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPSDriveInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pSDriveInfo = await _context.PSDrives.SingleOrDefaultAsync(m => m.Id == id);

            if (pSDriveInfo == null)
            {
                return NotFound();
            }

            return Ok(pSDriveInfo);
        }

        // PUT: api/Drives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPSDriveInfo([FromRoute] int id, [FromBody] PSDrive pSDriveInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pSDriveInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(pSDriveInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PSDriveInfoExists(id))
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

        // POST: api/Drives
        [HttpPost]
        public async Task<IActionResult> PostPSDriveInfo([FromBody] PSDrive pSDriveInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PSDrives.Add(pSDriveInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPSDriveInfo", new { id = pSDriveInfo.Id }, pSDriveInfo);
        }

        // DELETE: api/Drives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePSDriveInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pSDriveInfo = await _context.PSDrives.SingleOrDefaultAsync(m => m.Id == id);
            if (pSDriveInfo == null)
            {
                return NotFound();
            }

            _context.PSDrives.Remove(pSDriveInfo);
            await _context.SaveChangesAsync();

            return Ok(pSDriveInfo);
        }

        private bool PSDriveInfoExists(int id)
        {
            return _context.PSDrives.Any(e => e.Id == id);
        }
    }
}