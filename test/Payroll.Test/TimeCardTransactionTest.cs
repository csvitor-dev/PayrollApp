using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Assets;
using Payroll.Application.Contracts.Classifications;
using Payroll.Core.Contracts;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Test;

[TestFixture]
public class TimeCardTransactionTest
{
    [Test]
    public void Test_TimeCardTransactionSuccess()
    {
        int id = 5;
        AddHourlyEmployee t = new(id, "Bill", "Home", 15.25);
        t.Execute();

        DateTime date = new(2005, 7, 31);
        TimeCardTransaction tct = new(id, date, 8.0);
        tct.Execute();

        Employee? e = PayrollDB.GetEmployee(id);
        Assert.IsNotNull(e);

        IPaymentClassification pc = e.Classification;
        Assert.IsTrue(pc is HourlyClassification);
        HourlyClassification hc = (pc as HourlyClassification)!;

        TimeCard? tc = hc.GetTimeCard(date);
        Assert.IsNotNull(tc);
        Assert.That(tc.Hours, Is.EqualTo(8.0));
    }

    [Test]
    public void Test_TimeCardTransactionFail()
    {
        int id = 6;
        AddSalariedEmployee t = new(id, "Jones", "Home", 1200.00);
        t.Execute();

        DateTime date = new(2007, 10, 23);
        TimeCardTransaction tct = new(
            id, date, 8.0
        );
        Assert.Throws<InvalidOperationException>(() => tct.Execute());
    }
}