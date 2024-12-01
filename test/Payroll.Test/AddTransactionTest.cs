using Payroll.Application.Transactions.Add;
using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Methods;
using Payroll.Application.Contracts.Schedules;

using Payroll.Core.Contracts;
using Payroll.Core.Entities;
using Payroll.Core.Data;

namespace Payroll.Test;

[TestFixture]
public class AddTransactionTest
{
    [Test]
    public void Test_AddSalariedEmployee()
    {
        int id = 1;
        AddSalariedEmployee t = new(id, "Bob", "Home", 1000.00);
        t.Execute();

        Employee e = PayrollDb.GetEmployee(id)!;
        Assert.That(e.Name, Is.EqualTo("Bob"));

        IPaymentClassification pc = e.Classification;
        Assert.That(pc is SalariedClassification, Is.True);

        SalariedClassification sc = (pc as SalariedClassification)!;
        Assert.That(sc.Salary, Is.EqualTo(1000.00));
        
        IPaymentSchedule ps = e.Schedule;
        Assert.That(ps is MonthlySchedule, Is.True);

        IPaymentMethod pm = e.Method;
        Assert.That(pm is HoldMethod, Is.True);
    }

    [Test]
    public void Test_AddHourlyEmployee()
    {
        int id = 2;
        AddHourlyEmployee t = new(id, "Carl", "Home", 5.5);
        t.Execute();

        Employee e = PayrollDb.GetEmployee(id)!;
        Assert.That(e.Name, Is.EqualTo("Carl"));

        IPaymentClassification pc = e.Classification;
        Assert.That(pc is HourlyClassification, Is.True);

        HourlyClassification hc = (pc as HourlyClassification)!;
        Assert.That(hc.HourlyRate, Is.EqualTo(5.5));
        Assert.That(hc.TimeCards.Count, Is.EqualTo(0));

        IPaymentSchedule ps = e.Schedule;
        Assert.That(ps is WeeklySchedule, Is.True);

        IPaymentMethod pm = e.Method;
        Assert.That(pm is HoldMethod, Is.True);
    }

    [Test]
    public void Test_AddCommissionedEmployee()
    {
        int id = 3;
        AddCommissionedEmployee t = new(id, "Daniel", "Home", 1000, 4.5);
        t.Execute();

        Employee e = PayrollDb.GetEmployee(id)!;
        Assert.That(e.Name, Is.EqualTo("Daniel"));

        IPaymentClassification pc = e.Classification;
        Assert.That(pc is CommissionedClassification, Is.True);

        CommissionedClassification cc = (pc as CommissionedClassification)!;
        Assert.That(cc.Salary, Is.EqualTo(1000));
        Assert.That(cc.CommissionRate, Is.EqualTo(4.5));
        Assert.That(cc.SalesReceipts, Is.Empty);

        IPaymentSchedule ps = e.Schedule;
        Assert.That(ps is BiweeklySchedule, Is.True);

        IPaymentMethod pm = e.Method;
        Assert.That(pm is HoldMethod, Is.True);
    }
}