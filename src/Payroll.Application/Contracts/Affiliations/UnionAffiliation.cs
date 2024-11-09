using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Contracts.Affiliations;

public class UnionAffiliation : IAffiliation
{
    private readonly IList<ServiceCharge> _charges = [];
    
    public void AddServiceCharge(ServiceCharge charge)
        => _charges.Add(charge);
    public ServiceCharge? GetServiceCharge(DateTime date)
        => _charges.FirstOrDefault(c => c.Date == date);
}