using Payroll.Core.Entities;

namespace Payroll.Core.Data;

public class PayrollDB
{
    private static readonly Dictionary<int, Employee> _employees = [];

    public static void AddEmployee(int id, Employee employee)
        => _employees.Add(id, employee);

    public static Employee GetEmployee(int empID) 
        => _employees[empID];
}