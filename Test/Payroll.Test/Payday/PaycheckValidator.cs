using Payroll.Core.Entities;

namespace Payroll.Test.Payday;

public static class PaycheckValidator
{
    public static void Validate(Paycheck? paycheck, DateTime payDate, double pay) 
        => Validate(paycheck, payDate, 0.0, pay);

    public static void Validate(Paycheck? paycheck, DateTime payDate, double deductions, double pay)
    {
        Assert.That(paycheck, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(paycheck.PayDate, Is.EqualTo(payDate));
            Assert.That(paycheck.GrossPay, Is.EqualTo(pay + deductions));
            Assert.That(paycheck.GetField("Disposition"), Is.EqualTo("Hold"));
            Assert.That(paycheck.Deductions, Is.EqualTo(deductions));
            Assert.That(paycheck.NetPay, Is.EqualTo(pay));
        });
    }
}