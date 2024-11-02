using Payroll.Core.Contracts;

namespace Payroll.Application.Contracts.Classifications;

public class CommissionedClassification(double salary, double commissionRate) : IPaymentClassification
{
    public double Salary { get; set; } = salary;
    public double CommissionRate { get; set; } = commissionRate;
    public IList<string> SalesReciepts { get; } = [];
}