using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Contracts.Affiliations;

public class UnionAffiliation : IAffiliation
{
    private readonly IList<ServiceCharge> _charges = [];
    
    public int MemberId { get; }
    public double Dues { get; set; }
    
    public UnionAffiliation() { }

    public UnionAffiliation(int memberId, double dues)
    {
        MemberId = memberId;
        Dues = dues;
    }
    
    public void AddServiceCharge(ServiceCharge charge)
        => _charges.Add(charge);
    public ServiceCharge? GetServiceCharge(DateTime date)
        => _charges.FirstOrDefault(c => c.Date == date);
}