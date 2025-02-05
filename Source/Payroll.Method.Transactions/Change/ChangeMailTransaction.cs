using Methods.Contracts;
using Payroll.Core.Contracts;

namespace Payroll.Methods.Transactions.Change;

public class ChangeMailTransaction
    (int id, string address) : ChangeMethodTransaction(id)
{
    protected override IPaymentMethod Method
        => new MailMethod(address);
}