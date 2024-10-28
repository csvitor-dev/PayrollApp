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
}