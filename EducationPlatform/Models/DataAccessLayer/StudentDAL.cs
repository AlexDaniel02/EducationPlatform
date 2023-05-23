using EducationPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.DataAccessLayer
{
    public class StudentDAL : BaseDAL<Student>
    {
        public StudentDAL(EducationPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
