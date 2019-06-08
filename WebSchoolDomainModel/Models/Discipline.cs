using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSchoolDomainModel.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public List<Employee> Employees { get; set; }
        public List<EducationalClass> EducationalClasses { get; set; }
    }
}
