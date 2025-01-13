using Payroll.Core.Data;

namespace Payroll.Application.Transactions.Delete;

public class DeleteEmployeeTransaction(int empId) : ITransaction
{
    public void Execute()
        => PayrollDb.DeleteEmployee(empId);
}