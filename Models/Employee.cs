using System;
using System.Collections.Generic;

namespace EmployeeCRUDApi.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Department { get; set; }

    public decimal? Salary { get; set; }
}
