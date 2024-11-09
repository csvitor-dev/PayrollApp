using Payroll.Core.Entities;

namespace Payroll.Application.Transactions.Change;

public sealed class ChangeNameTransaction(int id, string newName) : ChangeEmployeeTransaction(id)
{
    protected override void Change(Employee employee)
        => employee.Name = newName;
}