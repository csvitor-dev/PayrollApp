using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Contracts.Classifications;

public class SalariedClassification(double salary) : IPaymentClassification
{
    public double Salary { get; set; } = salary;
    
    public double CalculatePay(Paycheck paycheck)
    {
        return salary;
    }
}