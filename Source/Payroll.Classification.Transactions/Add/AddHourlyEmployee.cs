using Payroll.Classifications.Contracts;
using Payroll.Core.Contracts;
using Payroll.Schedules.Contracts;
using Payroll.Transactions.Base;

namespace Payroll.Classification.Transactions.Add;

public class AddHourlyEmployee
    (int id, string name, string address, double hourlyRate)
    : AddEmployeeTransaction(id, name, address)
{
    protected override IPaymentClassification MakeClassification()
        => new HourlyClassification(hourlyRate);

    protected override IPaymentSchedule MakeSchedule()
        => new WeeklySchedule();
}