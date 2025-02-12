using Payroll.Application.Contracts.Methods;
using Payroll.Core.Contracts;
using Payroll.Transactions.Change;

namespace Payroll.Application.Transactions.Change.Methods;

public class ChangeDirectTransaction
    (int id, string bank, string account) : ChangeMethodTransaction(id)
{
    protected override IPaymentMethod Method 
        => new DirectMethod(bank, account);
}