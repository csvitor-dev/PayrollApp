using Payroll.Core.Contracts;

namespace Payroll.Application.Contracts.Classifications;

public class MailMethod(string address) : IPaymentMethod
{
    public string Address { get; set; } = address;
}