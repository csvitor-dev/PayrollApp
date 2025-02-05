using Payroll.Core.Entities;
using Payroll.Transactions.Base;

namespace Payroll.Transactions.Change;

public sealed class ChangeNameTransaction(int id, string newName) : ChangeEmployeeTransaction(id)
{
    protected override void Change(Employee employee)
        => employee.Name = newName;
}