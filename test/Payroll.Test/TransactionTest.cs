using Payroll.Application.Transactions.Add;
using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;

using Payroll.Core.Contracts;
using Payroll.Core.Entities;
using Payroll.Core.Data;

namespace Payroll.Test;

[TestFixture]
public class TransactionTest
{
    [Test]
    public void Test_AddSalariedEmployee()
    {
        int id = 1;
        AddSalariedEmployee t = new(id, "Bob", "Home", 1000.00);
        t.Execute();

        Employee e = PayrollDB.GetEmployee(id);
        Assert.That(e.Name, Is.EqualTo("Bob"));

        IPaymentClassification pc = e.Classification;
        Assert.IsTrue(pc is SalariedClassification);

        SalariedClassification sc = (pc as SalariedClassification)!;
        Assert.That(sc.Salary, Is.EqualTo(1000.00));
        
        IPaymentSchedule ps = e.Schedule;
        Assert.IsTrue(ps is MonthlySchedule);

        IPaymentMethod pm = e.Method;
        Assert.IsTrue(pm is HoldMethod);
    }

    [Test]
    public void Test_AddHourlyEmployee()
    {
        int id = 2;
        AddHourlyEmployee t = new(id, "Carl", "Home", 5.5);
        t.Execute();

        Employee e = PayrollDB.GetEmployee(id);
        Assert.That(e.Name, Is.EqualTo("Carl"));

        IPaymentClassification pc = e.Classification;
        Assert.IsTrue(pc is HourlyClassification);

        HourlyClassification hc = (pc as HourlyClassification)!;
        Assert.That(hc.HourlyRate, Is.EqualTo(5.5));
        Assert.That(hc.TimeCards.Count, Is.EqualTo(0));

        IPaymentSchedule ps = e.Schedule;
        Assert.IsTrue(ps is WeeklySchedule);

        IPaymentMethod pm = e.Method;
        Assert.IsTrue(pm is HoldMethod);
    }

    public void Test_AddCommisionedEmployee()
    {
        int id = 3;
        AddCommisionedEmployee t = new(id, "Daniel", "Home", 1000, 4.5);
        t.Execute();

        Employee e = PayrollDB.GetEmployee(id);
        Assert.That(e.Name, Is.EqualTo("Daniel"));

        IPaymentClassification pc = e.Classification;
        Assert.IsTrue(pc is CommisionedClassification);

        CommissionedClassification cc = (pc as CommissionedClassification)!;
        Assert.That(cc.Salary, Is.EqualTo(1000));
        Assert.That(cc.CommissionRate, Is.EqualTo(5.5));
        Assert.That(cc.SalesReciepts.Length, Is.EqualTo(0));

        IPaymentSchedule ps = e.Schedule;
        Assert.IsTrue(ps is BiweeklySchedule);

        IPaymentMethod pm = e.Method;
        Assert.IsTrue(pm is HoldMethod);
    }
}