using Payroll.Core.Entities;

namespace Payroll.Test.Payday;

public class PaycheckValidator
{
    public static void Validate(Paycheck? paycheck, DateTime payDate, double pay)
    {
        Assert.That(paycheck, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(paycheck.PayDate, Is.EqualTo(payDate));
            Assert.That(paycheck.GrossPay, Is.EqualTo(pay));
            Assert.That(paycheck.GetField("Disposition"), Is.EqualTo("Hold"));
            Assert.That(paycheck.Deductions, Is.EqualTo(0.0));
            Assert.That(paycheck.NetPay, Is.EqualTo(pay));
        });
    }
}