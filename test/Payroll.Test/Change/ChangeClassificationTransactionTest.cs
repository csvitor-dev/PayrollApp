using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;
using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Change.Classification;

using Payroll.Core.Contracts;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Test.Change;

[TestFixture]
public class ChangeClassificationTransactionTest
{
    [Test]
    public void Test_ChangeHourlyTransaction()
    {
        int id = 12;
        AddCommissionedEmployee t = new(id, "Lance", "Home", 2500, 3.2);
        ChangeHourlyTransaction cht = new(id, 27.52);
        
        t.Execute();
        cht.Execute();
        Employee? e = PayrollDb.GetEmployee(id);
        IPaymentClassification? pc = e?.Classification;
        HourlyClassification? hc = pc as HourlyClassification;
        IPaymentSchedule? ps = e?.Schedule;
        
        Assert.Multiple(() =>
        {
            Assert.That(e, Is.Not.Null);
            Assert.That(pc, Is.Not.Null);
            Assert.That(pc is HourlyClassification, Is.True);
            Assert.That(hc, Is.Not.Null);
            Assert.That(ps, Is.Not.Null);
        });
        
        Assert.Multiple(() =>
        {
            Assert.That(hc.HourlyRate, Is.EqualTo(27.52));
            Assert.That(ps is WeeklySchedule, Is.True);
        });
    }
    
    [Test]
    public void Test_ChangeSalariedTransaction()
    {
        int id = 13;
        AddHourlyEmployee t = new(id, "Kelvin", "Home", 2.7);
        ChangeSalariedTransaction cst = new(id, 1750.85);
        
        t.Execute();
        cst.Execute();
        Employee? e = PayrollDb.GetEmployee(id);
        IPaymentClassification? pc = e?.Classification;
        SalariedClassification? sc = pc as SalariedClassification;
        IPaymentSchedule? ps = e?.Schedule;
        
        Assert.Multiple(() =>
        {
            Assert.That(e, Is.Not.Null);
            Assert.That(pc, Is.Not.Null);
            Assert.That(pc is SalariedClassification, Is.True);
            Assert.That(sc, Is.Not.Null);
            Assert.That(ps, Is.Not.Null);
        });
        
        Assert.Multiple(() =>
        {
            Assert.That(sc.Salary, Is.EqualTo(1750.85));
            Assert.That(ps is MonthlySchedule, Is.True);
        });
    }

    [Test]
    public void Test_ChangeCommissionedTransaction()
    {
        int id = 14;
        AddSalariedEmployee t = new(id, "Erick", "Home", 2045.70);
        ChangeCommissionedTransaction cct = new(id, 12.15, 1905.00);
        
        t.Execute();
        cct.Execute();
        Employee? e = PayrollDb.GetEmployee(id);
        IPaymentClassification? pc = e?.Classification;
        CommissionedClassification? cc = pc as CommissionedClassification;
        IPaymentSchedule? ps = e?.Schedule;
        
        Assert.Multiple(() =>
        {
            Assert.That(e, Is.Not.Null);
            Assert.That(pc, Is.Not.Null);
            Assert.That(pc is CommissionedClassification, Is.True);
            Assert.That(cc, Is.Not.Null);
            Assert.That(ps, Is.Not.Null);
        });
        
        Assert.Multiple(() =>
        {
            Assert.That(cc.CommissionRate, Is.EqualTo(12.15));
            Assert.That(cc.Salary, Is.EqualTo(1905.00));
            Assert.That(ps is BiweeklySchedule, Is.True);
        });
    }
}