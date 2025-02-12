using Payroll.Application.Contracts.Methods;
using Payroll.Core.Contracts;
using Payroll.Transactions.Change;

namespace Payroll.Application.Transactions.Change.Methods;

public class ChangeHoldTransaction(int id) : ChangeMethodTransaction(id)
{
    protected override IPaymentMethod Method
        => new HoldMethod();
}