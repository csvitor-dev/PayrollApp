using Payroll.Core.Entities;

namespace Payroll.Core.Data;

public static class PayrollDb
{
    private static readonly Dictionary<int, Employee> s_Employees = [];
    private static readonly Dictionary<int, Employee> s_Affiliations = [];

    // Employee Table
    public static void AddEmployee(int id, Employee employee)
        => s_Employees.Add(id, employee);

    public static Employee? GetEmployee(int empId)
        => s_Employees.GetValueOrDefault(empId);
    
    public static IList<Employee> GetEmployees()
        => s_Employees.Values.ToList();

    public static void DeleteEmployee(int empId)
        => s_Employees.Remove(empId);

    // Affiliation Table
    public static void AddUnionMember(int memberId, Employee employee)
    {
        if (s_Employees.ContainsKey(employee.ID) is false)
            throw new InvalidOperationException("Employee does not exist");
        s_Affiliations.Add(memberId, employee);
    }

    public static Employee? GetUnionMember(int memberId)
        => s_Affiliations.GetValueOrDefault(memberId);

    public static void RemoveUnionMember(int memberId)
        => s_Affiliations.Remove(memberId);
}