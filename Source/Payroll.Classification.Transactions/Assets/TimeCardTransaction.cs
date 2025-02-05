using Payroll.Classifications.Assets;
using Payroll.Classifications.Contracts;
using Payroll.Core.Contracts;
using Payroll.Infrastructure.Data;

namespace Payroll.Classification.Transactions.Assets;

public class TimeCardTransaction(int id, DateTime date, double hours) : ITransaction
{
    public void Execute()
    {
        var e = PayrollDb.GetEmployee(id);

        if (e is null) throw new InvalidOperationException("No such employee");

        if (e.Classification is not HourlyClassification hc) 
            throw new InvalidOperationException("No hourly classification");
        hc.AddTimeCard(new TimeCard(date, hours));
    }
}