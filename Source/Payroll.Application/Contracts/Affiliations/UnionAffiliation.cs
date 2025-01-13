using Payroll.Application.Extensions;
using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Contracts.Affiliations;

public class UnionAffiliation : IAffiliation
{
    private readonly IList<ServiceCharge> _charges = [];
    
    public int MemberId { get; }
    public double Dues { get; }
    
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
    
    public double CalculateDeductions(Paycheck paycheck)
    {
        var fridays = NumberOfFridaysInPayPeriod(paycheck.StartDate, paycheck.PayDate);
        var chargesAmountInPeriod = from charges in _charges
            where charges.Date.IsInPayPeriod(paycheck)
            select charges.Amount;
        
        return Dues * fridays + chargesAmountInPeriod.Sum();
    }

    private static int NumberOfFridaysInPayPeriod(DateTime start, DateTime end)
    {
        var fridays = 0;

        for (var day = start; day <= end; day = day.AddDays(1))
            if (day.DayOfWeek == DayOfWeek.Friday)
            {
                fridays++;
                day = day.AddDays(6);
            }

        return fridays;
    }
}