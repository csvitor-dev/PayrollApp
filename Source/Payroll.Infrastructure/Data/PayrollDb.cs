using Payroll.Core.Entities;

namespace Payroll.Infrastructure.Data;

public static class PayrollDb
{
    private static readonly Dictionary<int, Employee> Employees = [];
    private static readonly Dictionary<int, Employee> Affiliations = [];

    // Employee Table
    public static void AddEmployee(int id, Employee employee)
        => Employees.Add(id, employee);

    public static Employee? GetEmployee(int empId)
        => Employees.GetValueOrDefault(empId);
    
    public static IList<Employee> GetEmployees()
        => Employees.Values.ToList();

    public static void DeleteEmployee(int empId)
        => Employees.Remove(empId);

    // Affiliation Table
    public static void AddUnionMember(int memberId, Employee employee)
    {
        if (Employees.ContainsKey(employee.ID) is false)
            throw new InvalidOperationException("Employee does not exist");
        Affiliations.Add(memberId, employee);
    }

    public static Employee? GetUnionMember(int memberId)
        => Affiliations.GetValueOrDefault(memberId);

    public static void RemoveUnionMember(int memberId)
        => Affiliations.Remove(memberId);
}