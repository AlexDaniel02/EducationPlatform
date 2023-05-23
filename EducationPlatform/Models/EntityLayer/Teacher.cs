using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public List<ClassSubject> ClassSubjects { get; set; }
        public Teacher()
        {
            ClassSubjects = new List<ClassSubject>();
        }
    }
}
