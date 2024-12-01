using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Contracts.Methods;

public class MailMethod(string address) : IPaymentMethod
{
    public string Address { get; set; } = address;

    public void Pay(Paycheck paycheck)
    {
    }
}