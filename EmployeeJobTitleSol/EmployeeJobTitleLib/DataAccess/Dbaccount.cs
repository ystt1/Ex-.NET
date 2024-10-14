using System;
using System.Collections.Generic;

namespace EmployeeJobTitleLib.DataAccess;

public partial class Dbaccount
{
    public string AccountId { get; set; } = null!;

    public string AccountPassword { get; set; } = null!;

    public string? FullName { get; set; }

    public int? AccountRole { get; set; }
}
