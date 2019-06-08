using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSchoolDomainModel.Models
{
    public class Pupil
    {
        public int PupilId { get; set; }
        public string PupilLastName { get; set; }
        public string PupilFirstName { get; set; }
        public string PupilMiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public int EducationalClassId { get; set; }
        public EducationalClass EducationalClass { get; set; }
    }
}
