using System.Collections.Generic;
using System.Security.Claims;

namespace EducationPlatform.Models.EntityLayer
{
    public class Student:BaseEntity
    {     
        public Class Class { get; set; }
        public string Name { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Absence> Absences { get; set; }

        public override string? ToString()
        {
            return Name;
        }
    }
}