using Payroll.Core.Entities;

namespace Payroll.Core.Contracts;

public interface IAffiliation
{
    public double CalculateDeductions(Paycheck paycheck);
}