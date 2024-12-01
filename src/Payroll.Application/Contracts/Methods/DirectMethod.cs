using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Contracts.Methods;

public class DirectMethod(string bank, string account) : IPaymentMethod
{
    public string Bank { get; set; } = bank;
    public string Account { get; set; } = account;
    
    public void Pay(Paycheck paycheck)
    {
    }
}