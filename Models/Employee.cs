using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfoApp.Models
{
    public class Employee
    {
        public string Name { get; set; } = String.Empty;
        public string FatherName { get; set; } = String.Empty;

        public string cnic { get; set; } = String.Empty;

        public string Designation { get; set; } = String.Empty;

        public DateTime? DOB { get; set; }

        public Char Gender { get; set; }

        public string Department { get; set; } = String.Empty;

        public bool Manager { get; set; }
    }
}
