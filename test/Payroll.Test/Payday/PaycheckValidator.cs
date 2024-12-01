using Payroll.Core.Entities;

namespace Payroll.Test.Payday;

public class PaycheckValidator
{
    public static void Validate(Paycheck? pc, DateTime payDate, double pay)
    {
        Assert.That(pc, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(pc.PayDate, Is.EqualTo(payDate));
            Assert.That(pc.GrossPay, Is.EqualTo(pay));
            Assert.That(pc.GetField("Disposition"), Is.EqualTo("Hold"));
            Assert.That(pc.Deductions, Is.EqualTo(0.0));
            Assert.That(pc.NetPay, Is.EqualTo(pay));
        });
    }
}