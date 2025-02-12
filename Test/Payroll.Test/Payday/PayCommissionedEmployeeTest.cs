using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Assets;
using Payroll.Application.Transactions.Payday;

namespace Payroll.Test.Payday;

[TestFixture]
public class PayCommissionedEmployeeTest
{
    [Test]
    public void Test_PaySingleCommissionedEmployee_NoSalesReceipts()
    {
        int id = 28;
        AddCommissionedEmployee t = new(id, "Philips", "Home", 1000.0, 2.5);
        DateTime payDate = new(2001, 11, 9);
        PaydayTransaction pt = new(payDate);

        t.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(id);

        PaycheckValidator.Validate(pc, payDate, 1000.0);
    }

    [Test]
    public void Test_PaySingleCommissionedEmployee_OneSalesReceipts()
    {
        int id = 29;
        AddCommissionedEmployee t = new(id, "Wilson", "Home", 1575.0, 1.2);
        DateTime payDate = new(2001, 11, 9);
        SalesReceiptTransaction srt = new(id, payDate, 250.5);
        PaydayTransaction pt = new(payDate);

        t.Execute();
        srt.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(id);

        PaycheckValidator.Validate(pc, payDate, 1575.0 + 1.2 * 250.5);
    }

    [Test]
    public void Test_PaySingleCommissionedEmployee_OnWrongDate()
    {
        int id = 30;
        AddCommissionedEmployee t = new(id, "Aaron", "Home", 1205.0, 3.5);
        DateTime payDate = new(2001, 11, 4);
        SalesReceiptTransaction srt = new(id, payDate, 300.5);
        PaydayTransaction pt = new(payDate);

        t.Execute();
        srt.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(id);

        Assert.That(pc, Is.Null);
    }

    [Test]
    public void Test_PaySingleCommissionedEmployee_TwoSalesReceipts()
    {
        int id = 31;
        AddCommissionedEmployee t = new(id, "Jason", "Home", 1750.0, 2.1);
        DateTime payDate = new(2001, 11, 9);
        SalesReceiptTransaction srt1 = new(id, payDate, 150.0);
        SalesReceiptTransaction srt2 = new(id, payDate.AddDays(-1), 200.25);
        PaydayTransaction pt = new(payDate);

        t.Execute();
        srt1.Execute();
        srt2.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(id);

        PaycheckValidator.Validate(pc, payDate, 1750.0 + 2.1 * (150.0 + 200.25));
    }

    [Test]
    public void Test_PaySingleCommissionedEmployee_OnTwoPayPeriods()
    {
        int id = 32;
        AddCommissionedEmployee t = new(id, "Victor", "Home", 1200.0, 2.0);
        DateTime previousPeriod = new(2001, 11, 9);
        DateTime currentPeriod = new(2001, 11, 23);
        SalesReceiptTransaction srt1 = new(id, previousPeriod, 150.0);
        SalesReceiptTransaction srt2 = new(id, currentPeriod, 520.5);
        PaydayTransaction pt = new(currentPeriod);

        t.Execute();
        srt1.Execute();
        srt2.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(id);

        PaycheckValidator.Validate(pc, currentPeriod, 1200.0 + 2.0 * 520.5);
    }
}