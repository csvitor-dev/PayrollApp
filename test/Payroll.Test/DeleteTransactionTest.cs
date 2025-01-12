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
        var (addTransaction, expected) = EmployeeMockFactory.CreateCommissionedMock();
        var deleteTransaction = new DeleteEmployeeTransaction(expected.Id);
        
        addTransaction.Execute();
        deleteTransaction.Execute();
        var employee = PayrollDb.GetEmployee(expected.Id);
        
        Assert.That(employee, Is.Null);
    }
}