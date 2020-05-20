using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.Models;

namespace Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityInfosController : ControllerBase
    {
        private readonly UniversityContext _context;

        public UniversityInfosController(UniversityContext context)
        {
            _context = context;
        }

        // GET: api/UniversityInfos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UniversityInfo>>> GetUniversityInfos()
        {
            return await _context.UniversityInfos.ToListAsync();
        }

        // GET: api/UniversityInfos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UniversityInfo>> GetUniversityInfo(long id)
        {
            var universityInfo = await _context.UniversityInfos.FindAsync(id);
            

            if (universityInfo == null)
            {
                return NotFound();
            }

             

            return universityInfo;
        }

        // PUT: api/UniversityInfos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversityInfo(long id, UniversityInfo universityInfo)
        {
            if (id != universityInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(universityInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityInfoExists(id))
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

        // POST: api/UniversityInfos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UniversityInfo>> PostUniversityInfo(UniversityInfo universityInfo)
        {
            _context.UniversityInfos.Add(universityInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUniversityInfo), new { id = universityInfo.Id }, universityInfo);
        }

        // DELETE: api/UniversityInfos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UniversityInfo>> DeleteUniversityInfo(long id)
        {
            var universityInfo = await _context.UniversityInfos.FindAsync(id);
            if (universityInfo == null)
            {
                return NotFound();
            }

            _context.UniversityInfos.Remove(universityInfo);
            await _context.SaveChangesAsync();

            return universityInfo;
        }

        private bool UniversityInfoExists(long id)
        {
            return _context.UniversityInfos.Any(e => e.Id == id);
        }
    }
}
