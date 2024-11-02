using Payroll.Core.Data;

namespace Payroll.Application.Transactions.Delete;

public class DeleteEmployeeTransaction(int empID) : ITransaction
{
    private readonly int _empID = empID;

    public void Execute()
        => PayrollDB.DeleteEmployee(_empID);
}