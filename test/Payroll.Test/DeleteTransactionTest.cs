using Payroll.Application.Transactions.Add;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Test;

[TestFixture]
public class DeleteTransactionTest
{
    [Test]
    public void Test_DeleteEmployee()
    {
        int empId = 4;
        AddCommissionedEmployee t = new(empId, "Bill", "Home", 2500, 3.2);
        t.Execute();

        Employee e = PayrollDB.GetEmployee(empId);
        Assert.IsNotNull(e);

        DeleteEmployeeTransaction dt = new(empId);
        dt.Execute();

        e = PayrollDB.GetEmployee(empId);
        Assert.IsNull(e);
    }
}