using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;

using Payroll.Core.Contracts;

namespace Payroll.Application.Transactions.Add;

public class AddHourlyEmployee
    (int id, string name, string address, double hourlyRate)
    : AddEmployeeTransaction(id, name, address)
{
    protected override IPaymentClassification MakeClassification()
        => new HourlyClassification(hourlyRate);

    protected override IPaymentSchedule MakeSchedule()
        => new WeeklySchedule();
}