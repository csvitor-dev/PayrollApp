using Payroll.Core.Entities;

namespace Payroll.Application.Transactions.Change;

public sealed class ChangeAddressTransaction(int id, string newAddress) : ChangeEmployeeTransaction(id)
{
    protected override void Change(Employee employee)
        => employee.Address = newAddress;
}