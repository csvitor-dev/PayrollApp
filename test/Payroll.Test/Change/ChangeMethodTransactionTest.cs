using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Methods;
using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Change.Method;
using Payroll.Core.Contracts;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Test.Change;

[TestFixture]
public class ChangeMethodTransactionTest
{
    [Test]
    public void Test_ChangeDirectTransaction()
    {
        int id = 15;
        AddSalariedEmployee t = new(id, "John", "St. Louis", 2100.00);
        string bank = "021000322"; // ABA Routing Number - Bank of America
        string account = "298309-00";
        ChangeDirectTransaction cdt = new(id, bank, account);
        
        t.Execute();
        cdt.Execute();
        Employee? e = PayrollDb.GetEmployee(id);
        IPaymentMethod? pm = e?.Method;
        DirectMethod? dm = pm as DirectMethod;
        
        Assert.Multiple(() =>
        {
            Assert.That(e, Is.Not.Null);
            Assert.That(pm, Is.Not.Null);
            Assert.That(dm, Is.Not.Null);
        });
        Assert.Multiple(() =>
        {
            Assert.That(pm is DirectMethod, Is.True);
            Assert.That(dm.Bank, Is.EqualTo(bank));
            Assert.That(dm.Account, Is.EqualTo(account));
        });
    }

    [Test]
    public void Test_ChangeMailTransaction()
    {
        int id = 16;
        AddSalariedEmployee t = new(id, "Philips", "Home", 2550.50);
        string address = "St. Edson";
        ChangeMailTransaction cmt = new(id, address);
        
        t.Execute();
        cmt.Execute();
        Employee? e = PayrollDb.GetEmployee(id);
        IPaymentMethod? pm = e?.Method;
        MailMethod? mm = pm as MailMethod;
        
        Assert.Multiple(() =>
        {
            Assert.That(e, Is.Not.Null);
            Assert.That(pm, Is.Not.Null);
            Assert.That(mm, Is.Not.Null);
        });
        Assert.Multiple(() =>
        {
            Assert.That(pm is MailMethod, Is.True);
            Assert.That(mm.Address, Is.EqualTo(address));
        });
    }

    [Test]
    public void Test_ChangeHoldTransaction()
    {
        int id = 17;
        AddHourlyEmployee t = new(id, "Victor", "Home", 13.1);
        ChangeHoldTransaction cht = new(id);
        
        t.Execute();
        cht.Execute();
        Employee? e = PayrollDb.GetEmployee(id);
        IPaymentMethod? pm = e?.Method;
        
        Assert.Multiple(() =>
        {
            Assert.That(e, Is.Not.Null);
            Assert.That(pm, Is.Not.Null);
        });
        Assert.That(pm is HoldMethod, Is.True);
    }
}