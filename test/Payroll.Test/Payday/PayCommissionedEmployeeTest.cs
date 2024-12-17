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
}