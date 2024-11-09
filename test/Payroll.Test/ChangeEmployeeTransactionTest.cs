using Payroll.Application.Transactions.Add;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Test;

[TestFixture]
public class ChangeEmployeeTransactionTest
{
    [Test]
    public void Test_ChangeNameTransaction()
    {
        int empId = 10;
        AddHourlyEmployee t = new(empId, "Bill", "Home", 15.25);
        ChangeNameTransaction cnt = new(empId, "Bob");

        t.Execute();
        cnt.Execute();
        Employee? e = PayrollDb.GetEmployee(empId);
        
        Assert.That(e, Is.Not.Null);
        Assert.That(e.Name, Is.EqualTo("Bob"));
    }
}