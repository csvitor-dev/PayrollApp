using Payroll.Application.Contracts.Classifications;
using Payroll.Core.Contracts;

namespace Payroll.Application.Transactions.Change.Method;

public class ChangeHoldTransaction(int id) : ChangeMethodTransaction(id)
{
    protected override IPaymentMethod Method
        => new HoldMethod();
}