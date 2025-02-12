using Payroll.Core.Entities;

namespace Payroll.Core.Contracts;

public interface IPaymentClassification
{
    public double CalculatePay(Paycheck paycheck);
}