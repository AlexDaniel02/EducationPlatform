using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    public class ClassSubject:BaseEntity
    {
        public Subject Subject { get; set; }
        public Class Class { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
