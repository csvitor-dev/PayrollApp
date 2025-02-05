using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Classifications.Contracts;

public class SalariedClassification(double salary) : IPaymentClassification
{
    public double Salary { get; set; } = salary;
    
    public double CalculatePay(Paycheck paycheck) 
        => Salary;
}