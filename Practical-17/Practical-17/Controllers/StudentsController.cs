using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical_17.Contracts;
using Practical_17.Model;
using Practical_17.ViewModel;

namespace Practical_17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppContext _context;
        private readonly IStudentRepositories studentRepositories;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepositories studentRepositories
            ,IMapper mapper)
        {
            this.studentRepositories = studentRepositories;
            this.mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentViewVM>>> GetStudents()
        {
            var students =mapper.Map<List<StudentViewVM>>(await studentRepositories.GetAllAsync());
            return students;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await studentRepositories.GetAsync(id);
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
           
            try
            {
                if (id == student.Id)
                {
                    if (ModelState.IsValid)
                    {
                        await studentRepositories.UpdateAsync(student);

                    }
                }


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await studentRepositories.Exist(student.Id))
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
            if (ModelState.IsValid)
            {

                await studentRepositories.AddAsync(student);
            }

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await studentRepositories.Exist(id);
            if (student == null)
            {
                return NotFound();
            }
            await studentRepositories.DeleteAsync(id);
            return NoContent();
        }

    }
}
