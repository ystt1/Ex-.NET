using System;
using System.Collections.Generic;

namespace EmployeeJobTitleLib.DataAccess;

public partial class Employee
{
    public string EmployeeId { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public int? YearOfBirth { get; set; }

    public string? DepartmentName { get; set; }

    public string? JobTitleId { get; set; }

    public virtual JobTitle? JobTitle { get; set; }
}
