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
        var (t, expected) = EmployeeMockFactory.CreateSalariedMock();

        t.Execute();
        var e = PayrollDb.GetEmployee(expected.Id);
        var pc = e?.Classification;
        var sc = pc as SalariedClassification;
        var ps = e?.Schedule;
        var pm = e?.Method;

        Assert.That(e?.Name, Is.EqualTo(expected.Name));
        Assert.That(pc is SalariedClassification, Is.True);
        Assert.That(sc?.Salary, Is.EqualTo(expected.Salary));
        Assert.That(ps is MonthlySchedule, Is.True);
        Assert.That(pm is HoldMethod, Is.True);
    }

    [Test]
    public void Test_AddHourlyEmployee()
    {
        var (t, expected) = EmployeeMockFactory.CreateHourlyMock();
        t.Execute();

        var e = PayrollDb.GetEmployee(expected.Id);
        var pc = e?.Classification;
        var hc = pc as HourlyClassification;
        var ps = e?.Schedule;
        var pm = e?.Method;

        Assert.That(e?.Name, Is.EqualTo(expected.Name));
        Assert.That(pc is HourlyClassification, Is.True);
        Assert.That(hc?.HourlyRate, Is.EqualTo(expected.HourlyRate));
        Assert.That(hc?.TimeCards, Is.Empty);
        Assert.That(ps is WeeklySchedule, Is.True);
        Assert.That(pm is HoldMethod, Is.True);
    }

    [Test]
    public void Test_AddCommissionedEmployee()
    {
        var (t, expected) = EmployeeMockFactory.CreateCommissionedMock();

        t.Execute();
        var e = PayrollDb.GetEmployee(expected.Id);
        var pc = e?.Classification;
        var cc = pc as CommissionedClassification;
        var ps = e?.Schedule;
        var pm = e?.Method;

        Assert.That(e?.Name, Is.EqualTo(expected.Name));
        Assert.That(pc is CommissionedClassification, Is.True);
        Assert.That(cc?.Salary, Is.EqualTo(expected.Salary));
        Assert.That(cc?.CommissionRate, Is.EqualTo(expected.CommissionRate));
        Assert.That(cc?.SalesReceipts, Is.Empty);
        Assert.That(ps is BiweeklySchedule, Is.True);
        Assert.That(pm is HoldMethod, Is.True);
    }
}