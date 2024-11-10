using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;
using Payroll.Application.Transactions.Add;
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
        IPaymentSchedule? ps = e?.Schedule;
        HourlyClassification? hc = pc as HourlyClassification;
        
        Assert.Multiple(() =>
        {
            Assert.That(e, Is.Not.Null);
            Assert.That(pc, Is.Not.Null);
            Assert.That(pc is HourlyClassification, Is.True);
            Assert.That(hc.HourlyRate, Is.EqualTo(27.52));
            Assert.That(ps is WeeklySchedule, Is.True);
        });
    }
}