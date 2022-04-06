using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practical_17.Model;

namespace Practical_17.Model
{
    public class AppContext:DbContext
    {
        public AppContext(DbContextOptions  dbContext) : base(dbContext)
        {
        }
        public DbSet<Student> Students { get; set; }

    }
}
