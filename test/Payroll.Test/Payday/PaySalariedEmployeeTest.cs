using Payroll.Application.Transactions.Add;

namespace Payroll.Test.Payday;

[TestFixture]
public class PaySalariedEmployeeTest
{
    [Test]
    public void Test_PaySingleSalariedEmployee()
    {
        int id = 1;
        DateTime payDate = new DateTime(2001, 11, 30);
        AddSalariedEmployee t = new(id, "Bob", "Home", 1000.00);
        PaydayTransaction pt = new(payDate);

        t.Execute();
        pt.Execute();
        Paycheck? pc = pt.GetPaycheck(id);

        Assert.That(pc, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(pc.PayDate, Is.EqualTo(payDate));
            Assert.That(pc.GrossPay, Is.EqualTo(1000.00));
            Assert.That(pc.GetField("Disposition"), Is.EqualTo("Hold"));
            Assert.That(pc.Deductions, Is.EqualTo(0.0));
            Assert.That(pc.NetPay, Is.EqualTo(1000.00));
        });
    }

    [Test]
    public void Test_PaySingleSalariedEmployee_OnWrongDate()
    {
        int id = 1;
        DateTime payDate = new DateTime(2001, 11, 29);
        AddSalariedEmployee t = new(id, "Bob", "Home", 1000.00);
        PaydayTransaction pt = new(payDate);
        
        t.Execute();
        pt.Execute();
        Paycheck? pc = pt.GetPaycheck(id);
        
        Assert.That(pc, Is.Null);
    }
}