using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Methods.Contracts;

public class MailMethod(string address) : IPaymentMethod
{
    public string Address { get; set; } = address;

    public void Pay(Paycheck paycheck)
    {
    }
}