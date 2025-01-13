using Payroll.Application.Contracts.Classifications;
using Payroll.Infrastructure.Data;

namespace Payroll.Application.Transactions.Assets;

public class TimeCardTransaction(int id, DateTime date, double hours) : ITransaction
{
    public void Execute()
    {
        var e = PayrollDb.GetEmployee(id);

        if (e is null) throw new InvalidOperationException("No such employee");

        if (e.Classification is not HourlyClassification hc) 
            throw new InvalidOperationException("No hourly classification");
        hc.AddTimeCard(new(date, hours));
    }
}