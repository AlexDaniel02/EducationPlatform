using EducationPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.DataAccessLayer
{
    public class GradeDAL : BaseDAL<Grade>
    {
        public GradeDAL(EducationPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
