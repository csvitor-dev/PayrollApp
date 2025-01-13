using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Transactions.Change.Method;

public abstract class ChangeMethodTransaction
    (int id) : ChangeEmployeeTransaction(id)
{
    protected sealed override void Change(Employee employee) 
        => employee.Method = Method;
    protected abstract IPaymentMethod Method { get; }
}