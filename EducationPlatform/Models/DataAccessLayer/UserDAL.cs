using EducationPlatform.Models.EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.DataAccessLayer
{
    public class UserDAL : BaseDAL<User>
    {
        public UserDAL(EducationPlatformDbContext dbContext) : base(dbContext)
        {

        }
        public User GetByUsername(string username)
        {
            return _dbSet.FirstOrDefault(u => u.Username == username);
        }
    }   
}
