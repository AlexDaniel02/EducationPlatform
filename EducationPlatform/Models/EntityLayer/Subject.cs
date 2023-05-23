using System.Collections.Generic;
using System.Windows.Documents;

namespace EducationPlatform.Models.EntityLayer
{
    public class Subject : BaseEntity
    {
            public string Name { get; set; }
            public List<ClassSubject> SubjectClasses { get; set; }

        public override string? ToString()
        {
            return Name;
        }
    }
}