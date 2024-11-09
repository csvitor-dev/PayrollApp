using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Change;
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
        string newName = "Bob";
        AddHourlyEmployee t = new(empId, "Bill", "Home", 15.25);
        ChangeNameTransaction cnt = new(empId, newName);

        t.Execute();
        cnt.Execute();
        Employee? e = PayrollDb.GetEmployee(empId);
        
        Assert.That(e, Is.Not.Null);
        Assert.That(e.Name, Is.EqualTo(newName));
    }

    [Test]
    public void Test_ChangeAddressTransaction()
    {
        int empId = 11;
        string newAddress = "St. Rowling";
        AddHourlyEmployee t = new(empId, "Chris", "Home", 12.95);
        ChangeAddressTransaction cdt = new(empId, newAddress);

        t.Execute();
        cdt.Execute();
        Employee? e = PayrollDb.GetEmployee(empId);
        
        Assert.That(e, Is.Not.Null);
        Assert.That(e.Address, Is.EqualTo(newAddress));
    }
}