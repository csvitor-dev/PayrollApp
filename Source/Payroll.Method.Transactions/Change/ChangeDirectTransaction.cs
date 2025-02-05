using Methods.Contracts;
using Payroll.Core.Contracts;

namespace Payroll.Methods.Transactions.Change;

public class ChangeDirectTransaction
    (int id, string bank, string account) : ChangeMethodTransaction(id)
{
    protected override IPaymentMethod Method 
        => new DirectMethod(bank, account);
}