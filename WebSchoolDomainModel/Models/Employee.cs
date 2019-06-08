using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSchoolDomainModel.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeMiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public List<Discipline> Disciplines { get; set; }
    }
}
