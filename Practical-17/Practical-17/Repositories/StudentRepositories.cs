using Practical_17.Contracts;
using Practical_17.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_17.Repositories
{
    public class StudentRepositories : GenericRepositories<Student>, IStudentRepositories
    {
        public StudentRepositories(AppContext context):base(context)
        {

        }
    }
}
