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
    public class StudentInfosController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentInfosController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/StudentInfos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentInfo>>> GetStudentInfos()
        {
            return await _context.StudentInfos.ToListAsync();
        }

        // GET: api/StudentInfos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentInfo>> GetStudentInfo(long id)
        {
            var studentInfo = await _context.StudentInfos.FindAsync(id);

            if (studentInfo == null)
            {
                return NotFound();
            }

            return studentInfo;
        }

        // PUT: api/StudentInfos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentInfo(long id, StudentInfo studentInfo)
        {
            if (id != studentInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentInfoExists(id))
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

        // POST: api/StudentInfos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentInfo>> PostStudentInfo(StudentInfo studentInfo)
        {
            _context.StudentInfos.Add(studentInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentInfo), new { id = studentInfo.Id }, studentInfo);
        }

        // DELETE: api/StudentInfos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentInfo>> DeleteStudentInfo(long id)
        {
            var studentInfo = await _context.StudentInfos.FindAsync(id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            _context.StudentInfos.Remove(studentInfo);
            await _context.SaveChangesAsync();

            return studentInfo;
        }

        private bool StudentInfoExists(long id)
        {
            return _context.StudentInfos.Any(e => e.Id == id);
        }
    }
}
