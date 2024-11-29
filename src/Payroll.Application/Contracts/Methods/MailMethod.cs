using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Contracts.Classifications;

public class MailMethod(string address) : IPaymentMethod
{
    public string Address { get; set; } = address;

    public void Pay(Paycheck paycheck)
    {
    }
}