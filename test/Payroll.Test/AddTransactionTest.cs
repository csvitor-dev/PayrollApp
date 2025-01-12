using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Methods;
using Payroll.Application.Contracts.Schedules;
using Payroll.Core.Data;
using TestUtilities.Mocks.Employee;

namespace Payroll.Test;

[TestFixture]
public class AddTransactionTest
{
    [Test]
    public void Test_AddSalariedEmployee()
    {
        var (transaction, expected) = EmployeeMockFactory.CreateSalariedMock();

        transaction.Execute();
        var employee = PayrollDb.GetEmployee(expected.Id);
        var classification = employee?.Classification;
        var salaried = classification as SalariedClassification;
        var schedule = employee?.Schedule;
        var method = employee?.Method;

        Assert.That(employee, Is.Not.Null);
        Assert.That(employee.Name, Is.EqualTo(expected.Name));
        Assert.That(classification is SalariedClassification, Is.True);
        Assert.That(salaried?.Salary, Is.EqualTo(expected.Salary));
        Assert.That(schedule is MonthlySchedule, Is.True);
        Assert.That(method is HoldMethod, Is.True);
    }

    [Test]
    public void Test_AddHourlyEmployee()
    {
        var (transaction, expected) = EmployeeMockFactory.CreateHourlyMock();

        transaction.Execute();
        var employee = PayrollDb.GetEmployee(expected.Id);
        var classification = employee?.Classification;
        var hourly = classification as HourlyClassification;
        var schedule = employee?.Schedule;
        var method = employee?.Method;
        
        Assert.That(employee, Is.Not.Null);
        Assert.That(employee?.Name, Is.EqualTo(expected.Name));
        Assert.That(classification is HourlyClassification, Is.True);
        Assert.That(hourly?.HourlyRate, Is.EqualTo(expected.HourlyRate));
        Assert.That(hourly?.TimeCards, Is.Empty);
        Assert.That(schedule is WeeklySchedule, Is.True);
        Assert.That(method is HoldMethod, Is.True);
    }

    [Test]
    public void Test_AddCommissionedEmployee()
    {
        var (transaction, expected) = EmployeeMockFactory.CreateCommissionedMock();

        transaction.Execute();
        var employee = PayrollDb.GetEmployee(expected.Id);
        var classification = employee?.Classification;
        var commissioned = classification as CommissionedClassification;
        var schedule = employee?.Schedule;
        var method = employee?.Method;

        Assert.That(employee, Is.Not.Null);
        Assert.That(employee?.Name, Is.EqualTo(expected.Name));
        Assert.That(classification is CommissionedClassification, Is.True);
        Assert.That(commissioned?.Salary, Is.EqualTo(expected.Salary));
        Assert.That(commissioned?.CommissionRate, Is.EqualTo(expected.CommissionRate));
        Assert.That(commissioned?.SalesReceipts, Is.Empty);
        Assert.That(schedule is BiweeklySchedule, Is.True);
        Assert.That(method is HoldMethod, Is.True);
    }
}