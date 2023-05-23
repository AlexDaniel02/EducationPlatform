using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    public class Absence : BaseEntity
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public DateTime Date { get; set; }
        public bool IsMotivated { get; set; }
    }
}
