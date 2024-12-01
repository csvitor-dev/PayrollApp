using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Methods;
using Payroll.Core.Contracts;

namespace Payroll.Application.Transactions.Change.Method;

public class ChangeMailTransaction
    (int id, string address) : ChangeMethodTransaction(id)
{
    protected override IPaymentMethod Method
        => new MailMethod(address);
}