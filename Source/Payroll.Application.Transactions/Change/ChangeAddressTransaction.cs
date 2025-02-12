using Payroll.Core.Entities;
using Payroll.Transactions.Base;

namespace Payroll.Application.Transactions.Change;

public sealed class ChangeAddressTransaction(int id, string newAddress) : ChangeEmployeeTransaction(id)
{
    protected override void Change(Employee employee)
        => employee.Address = newAddress;
}