using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Delete;

using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Test;

[TestFixture]
public class DeleteTransactionTest
{
    [Test]
    public void Test_DeleteEmployee()
    {
        int id = 4;
        AddCommissionedEmployee t = new(id, "Bill", "Home", 2500, 3.2);
        t.Execute();

        Employee? e = PayrollDB.GetEmployee(id);
        Assert.That(e, Is.Not.Null);

        DeleteEmployeeTransaction dt = new(id);
        dt.Execute();

        e = PayrollDB.GetEmployee(id);
        Assert.That(e, Is.Null);
    }
}