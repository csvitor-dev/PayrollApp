using Payroll.Application.Contracts.Classifications;
using Payroll.Core.Contracts;

namespace Payroll.Application.Transactions.Change.Method;

public class ChangeDirectTransaction
    (int id, string bank, string account) : ChangeMethodTransaction(id)
{
    protected override IPaymentMethod Method 
        => new DirectMethod(bank, account);
}