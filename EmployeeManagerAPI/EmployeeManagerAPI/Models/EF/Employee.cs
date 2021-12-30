using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagerAPI.Models.EF
{
    public partial class Employee
    {
        public int IDEmployee { get; set; }
        public string EmployeeName { get; set; }
        public int? IDDepartment { get; set; }
        public DateTime? DataOfJoining { get; set; }

        public virtual Department IDDepartmentNavigation { get; set; }
    }
}
