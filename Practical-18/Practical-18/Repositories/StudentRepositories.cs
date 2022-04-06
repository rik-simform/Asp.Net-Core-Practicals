using Practical_18.Contract;
using Practical_18.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_18.Repositories
{
    public class StudentRepositories : GenericRepository<Student>, IStudentRepositories
    {
        public StudentRepositories(ApplicationDbContext Context) : base(Context)
        {
        }
    }
}
