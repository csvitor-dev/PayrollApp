using Methods.Contracts;
using Payroll.Core.Contracts;

namespace Payroll.Methods.Transactions.Change;

public class ChangeHoldTransaction(int id) : ChangeMethodTransaction(id)
{
    protected override IPaymentMethod Method
        => new HoldMethod();
}