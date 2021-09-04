using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace misV3.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDomain { get; set; }
        public string DomainPassword { get; set; }
        public string EmployeeDep { get; set; }
        public string EmployeeIP { get; set; }
        public string EmployeePassword { get; set; }

    }
}
