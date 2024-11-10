using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;
using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Change.Classification;
using Payroll.Core.Contracts;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Test;

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
        });
        
        Assert.Multiple(() =>
        {
            Assert.That(hc.HourlyRate, Is.EqualTo(27.52));
            Assert.That(ps is WeeklySchedule, Is.True);
        });
    }
}