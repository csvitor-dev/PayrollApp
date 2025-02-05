using Payroll.Core.Contracts;
using Payroll.Infrastructure.Data;

namespace Payroll.Transactions.Base;

public class DeleteEmployeeTransaction(int empId) : ITransaction
{
    public void Execute()
        => PayrollDb.DeleteEmployee(empId);
}