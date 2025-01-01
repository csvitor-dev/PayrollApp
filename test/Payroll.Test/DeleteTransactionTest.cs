using Payroll.Application.Transactions.Delete;

using Payroll.Core.Data;
using TestUtilities.Mocks.Employee;

namespace Payroll.Test;

[TestFixture]
public class DeleteTransactionTest
{
    [Test]
    public void Test_DeleteEmployee()
    {
        var (t, expected) = EmployeeMockFactory.CreateCommissionedMock();
        var dt = new DeleteEmployeeTransaction(expected.Id);
        
        t.Execute();
        dt.Execute();
        var e = PayrollDb.GetEmployee(expected.Id);
        
        Assert.That(e, Is.Null);
    }
}