using Practical_16.Contracts;
using Practical_16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_16.Repositories
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        public StudentRepo(AppDbContext context) : base(context)
        {
        }
    }
}
