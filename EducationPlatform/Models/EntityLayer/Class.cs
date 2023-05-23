    using System.Collections.Generic;

namespace EducationPlatform.Models.EntityLayer
{
    public class Class : BaseEntity
    {
        public Specialization Specialization { get; set; }
        public string Name { get; set; }
        public List<ClassSubject> ClassSubjects { get; set; }
        public Teacher ClassMaster { get; set; }
        public List<Student> Students { get; set; }
        public Class()
        {
            ClassSubjects = new List<ClassSubject>();
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}