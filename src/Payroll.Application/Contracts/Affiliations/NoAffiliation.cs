using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Contracts.Affiliations;

public class NoAffiliation : IAffiliation
{
    public double CalculateDeductions(Paycheck paycheck) => default;
}
