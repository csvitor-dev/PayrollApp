using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;

using Payroll.Core.Contracts;

namespace Payroll.Application.Transactions.Add;

public class AddHourlyEmployee
    (int id, string name, string address, double hourlyRate)
    : AddEmployeeTransaction(id, name, address)
{
    private readonly double _hourlyRate = hourlyRate;

    protected override IPaymentClassification MakeClassification()
        => new HourlyClassification(_hourlyRate);

    protected override IPaymentSchedule MakeSchedule()
        => new WeeklySchedule();
}