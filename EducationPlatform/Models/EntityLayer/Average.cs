using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    public class Average : BaseEntity
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public double Value { get; set; }
    }
}
