using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Contracts.Classifications;

public class HoldMethod : IPaymentMethod
{
    public void Pay(Paycheck paycheck)
    {
    }
}