using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical_16.Contracts;
using Practical_16.Models;
using Practical_16.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo studentRepo;

        public StudentsController(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            return await studentRepo.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await studentRepo.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.id)
            {
                return BadRequest();
            }

            try
            {
                await studentRepo.UpdateAsync(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await studentRepo.IsExist(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await studentRepo.AddAsync(student);

            return CreatedAtAction("GetStudent", new { id = student.id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            await studentRepo.DeleteAsync(id);

            return Ok("Deleted Successfully");
        }

    }
}
