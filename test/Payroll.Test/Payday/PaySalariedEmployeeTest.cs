using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Payday;
using Payroll.Core.Entities;

namespace Payroll.Test.Payday;

[TestFixture]
public class PaySalariedEmployeeTest
{
    [Test]
    public void Test_PaySingleSalariedEmployee()
    {
        int id = 20;
        DateTime payDate = new DateTime(2001, 11, 30);
        AddSalariedEmployee t = new(id, "Bob", "Home", 1000.00);
        PaydayTransaction pt = new(payDate);

        t.Execute();
        pt.Execute();
        Paycheck? pc = pt.GetPaycheck(id);

        PaycheckValidator.Validate(pc, payDate, 1000.00);
    }

    [Test]
    public void Test_PaySingleSalariedEmployee_OnWrongDate()
    {
        int id = 21;
        DateTime payDate = new DateTime(2001, 11, 29);
        AddSalariedEmployee t = new(id, "Elliot", "Home", 1000.00);
        PaydayTransaction pt = new(payDate);

        t.Execute();
        pt.Execute();
        Paycheck? pc = pt.GetPaycheck(id);

        Assert.That(pc, Is.Null);
    }
}