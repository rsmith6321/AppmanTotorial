using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentUniversityTest.Models;

namespace StudentUniversityTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly UniversityContext _context;

        public UniversitiesController(UniversityContext context)
        {
            _context = context;
        }

        // GET: api/Universities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetUniversities()
        {
            return await _context.Universities.ToListAsync();
        }

        // GET: api/Universities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetUniversity(long id)
        {
            var university = await _context.Universities.FindAsync(id);

            if (university == null)
            {
                return NotFound();
            }

            return university;
        }

        // PUT: api/Universities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversity(long id, University university)
        {
            if (id != university.UniversityId)
            {
                return BadRequest();
            }

            _context.Entry(university).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityExists(id))
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

        // POST: api/Universities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<University>> PostUniversity(University university)
        {
            _context.Universities.Add(university);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUniversity", new { id = university.UniversityId }, university);
        }

        // DELETE: api/Universities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<University>> DeleteUniversity(long id)
        {
            var university = await _context.Universities.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }

            _context.Universities.Remove(university);
            await _context.SaveChangesAsync();

            return university;
        }

        private bool UniversityExists(long id)
        {
            return _context.Universities.Any(e => e.UniversityId == id);
        }
    }
}
