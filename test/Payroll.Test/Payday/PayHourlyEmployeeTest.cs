using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Assets;
using Payroll.Application.Transactions.Payday;
using Payroll.Core.Entities;

namespace Payroll.Test.Payday;

[TestFixture]
public class PayHourlyEmployeeTest
{
    [Test]
    public void Test_PaySingleHourlyEmployee_NoTimeCards()
    {
        int id = 22;
        AddHourlyEmployee t = new(id, "Bill", "Home", 15.25);
        DateTime payDate = new(2001, 11, 9);
        PaydayTransaction pt = new(payDate);

        t.Execute();
        pt.Execute();
        Paycheck? pc = pt.GetPaycheck(id);

        PaycheckValidator.Validate(pc, payDate, 0.0);
    }

    [Test]
    public void Test_PaySingleHourlyEmployee_OneTimeCard()
    {
        int id = 23;
        AddHourlyEmployee t = new(id, "Johnson", "Home", 12.75);
        DateTime payDate = new(2001, 11, 9);
        TimeCardTransaction tc = new(id, payDate, 2.0);
        PaydayTransaction pt = new(payDate);

        t.Execute();
        tc.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(id);

        PaycheckValidator.Validate(pc, payDate, 2.0 * 12.75);
    }

    [Test]
    public void Test_PaySingleHourlyEmployee_OvertimeOneTimeCard()
    {
        int id = 24;
        AddHourlyEmployee t = new(id, "Kane", "Home", 24.0);
        DateTime payDate = new(2001, 11, 9);
        TimeCardTransaction tc = new(id, payDate, 9.0);
        PaydayTransaction pt = new(payDate);

        t.Execute();
        tc.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(id);
        
        PaycheckValidator.Validate(pc, payDate, (8 + 1.5) * 24.0);
    }

    [Test]
    public void Test_PaySingleHourlyEmployee_OnWrongDate()
    {
        int id = 25;
        AddHourlyEmployee t = new(id, "Jason", "Home", 19.05);
        DateTime payDate = new(2001, 11, 8);
        TimeCardTransaction tc = new(id, payDate, 9.0);
        PaydayTransaction pt = new(payDate);
        
        t.Execute();
        tc.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(id);
        
        Assert.That(pc, Is.Null);
    }

    [Test]
    public void Test_PaySingleHourlyEmployee_TwoTimeCards()
    {
        int id = 26;
        AddHourlyEmployee t = new(id, "Erick", "Home", 20.05);
        DateTime payDate = new(2001, 11, 9);
        TimeCardTransaction tc1 = new(id, payDate, 2.0);
        TimeCardTransaction tc2 = new(id, payDate.AddDays(-1), 5.0);
        PaydayTransaction pt = new(payDate);
        
        t.Execute();
        tc1.Execute();
        tc2.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(id);
        
        PaycheckValidator.Validate(pc, payDate, 7.0 * 20.05);
    }

    [Test]
    public void Test_PaySingleHourlyEmployee_OnTwoPayPeriods()
    {
        int id = 27;
        AddHourlyEmployee t = new(id, "Mary", "Home", 21.15);
        DateTime currentPayDate = new(2001, 11, 9),
            previousPayDate = new(2001, 11, 2);
        TimeCardTransaction tc1 = new(id, currentPayDate, 2.0);
        TimeCardTransaction tc2 = new(id, previousPayDate, 5.0);
        PaydayTransaction pt = new(currentPayDate);
        
        t.Execute();
        tc1.Execute();
        tc2.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(id);
        
        PaycheckValidator.Validate(pc, currentPayDate, 2.0 * 21.15);
    }
}