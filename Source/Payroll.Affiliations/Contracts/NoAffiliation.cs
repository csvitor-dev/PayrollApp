using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Affiliations.Contracts;

public class NoAffiliation : IAffiliation
{
    public double CalculateDeductions(Paycheck paycheck) => 0;
}
