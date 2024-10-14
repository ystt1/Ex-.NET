using System;
using System.Collections.Generic;

namespace EmployeeJobTitleLib.DataAccess;

public partial class JobTitle
{
    public string JobTitleId { get; set; } = null!;

    public string JobTitleName { get; set; } = null!;

    public string? JobTitleDescription { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
