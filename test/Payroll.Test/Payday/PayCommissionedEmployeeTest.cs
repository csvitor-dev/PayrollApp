using Payroll.Application.Transactions.Add;
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
        DateTime payDate = new(2001, 11, 16);
        PaydayTransaction pt = new(payDate);
        
        t.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(id);
        
        PaycheckValidator.Validate(pc, payDate, 1000.0);
    }
}