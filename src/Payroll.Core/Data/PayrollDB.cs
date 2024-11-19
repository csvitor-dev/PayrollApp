using Payroll.Core.Entities;

namespace Payroll.Core.Data;

public static class PayrollDb
{
    private static readonly Dictionary<int, Employee> s_employees = [];
    private static readonly Dictionary<int, Employee> s_affiliations = [];

    // Employee Table
    public static void AddEmployee(int id, Employee employee)
        => s_employees.Add(id, employee);

    public static Employee? GetEmployee(int empId)
        => s_employees.GetValueOrDefault(empId);

    public static void DeleteEmployee(int empId)
        => s_employees.Remove(empId);

    // Affiliation Table
    public static void AddUnionMember(int memberId, Employee employee)
    {
        if (s_employees.ContainsKey(employee.ID) is false)
            throw new InvalidOperationException("Employee does not exist");
        s_affiliations.Add(memberId, employee);
    }

    public static Employee? GetUnionMember(int memberId)
        => s_affiliations.GetValueOrDefault(memberId);

    public static void RemoveUnionMember(int memberId)
        => s_affiliations.Remove(memberId);
}