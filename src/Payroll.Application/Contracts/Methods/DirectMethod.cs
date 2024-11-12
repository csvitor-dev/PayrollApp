using Payroll.Core.Contracts;

namespace Payroll.Application.Contracts.Classifications;

public class DirectMethod(string bank, string account) : IPaymentMethod
{
    public string Bank { get; set; } = bank;
    public string Account { get; set; } = account;
}