using System.Collections;
using System.Collections.Generic;

namespace EducationPlatform.Models.EntityLayer
{
    public class Specialization:BaseEntity
    {
        public string Name { get; set; }
        public List<Class> Classes { get; set; }
    }
}