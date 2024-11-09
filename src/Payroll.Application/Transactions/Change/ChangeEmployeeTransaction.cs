using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Application.Transactions.Change;

public abstract class ChangeEmployeeTransaction(int id) : ITransaction
{
    public void Execute()
    {
        Employee? e = PayrollDb.GetEmployee(id);
        
        if (e is null)
            throw new InvalidOperationException($"Employee with id {id} does not exist");
        Change(e);
    }
    protected abstract void Change(Employee employee);
}