using Payroll.Core.Entities;

namespace Payroll.Core.Contracts;

public interface IPaymentMethod
{
    public void Pay(Paycheck paycheck);
}