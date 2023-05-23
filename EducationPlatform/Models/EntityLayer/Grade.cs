using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.EntityLayer
{
    public class Grade : BaseEntity
    {
        public Subject Subject { get; set; }
        public Student Student { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public bool IsSemestrial { get; set; }


    }
}
