using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSchoolDomainModel.Models
{
    public class EducationalClass
    {
        public int EducationalClassId { get; set; }
        /// <summary>
        /// Буква класса
        /// </summary>
        public string EducationalClassLetter { get; set; }
        public int EducationalClassNumber { get; set; }
        public List<Pupil> Pupils { get; set; }
        public List<Discipline> Disciplines { get; set; }
    }
}
