using Payroll.Application.Transactions.Add;
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
}