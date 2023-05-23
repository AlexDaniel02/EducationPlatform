using EducationPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.DataAccessLayer
{
    public class AbsenceDAL : BaseDAL<Absence>
    {
        public AbsenceDAL(EducationPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
