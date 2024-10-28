using Payroll.Core.Contracts;

namespace Payroll.Application.Contracts.Classifications;

public class SalariedClassification(double salary) : IPaymentClassification
{
    public double Salary { get; set; } = salary;
}