using Payroll.Core.Entities;

namespace Payroll.Core.Contracts;

public interface IAffiliation
{
    public void AddServiceCharge(ServiceCharge charge);
    public ServiceCharge? GetServiceCharge(DateTime date);
}