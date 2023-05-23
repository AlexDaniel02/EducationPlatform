using EducationPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.DataAccessLayer
{
    public class ClassSubjectDAL : BaseDAL<ClassSubject>
    {
        public ClassSubjectDAL(EducationPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
