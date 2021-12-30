using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagerAPI.Models.EF
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int IDDepartment { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
