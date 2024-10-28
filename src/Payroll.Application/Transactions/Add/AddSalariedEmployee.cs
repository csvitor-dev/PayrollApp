using Payroll.Core.Contracts;
using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;

namespace Payroll.Application.Transactions.Add;

public class AddSalariedEmployee
    (int id, string name, string address, double salary) 
    : AddEmployeeTransaction(id, name, address)
{
    private readonly double _salary = salary;

    protected override IPaymentClassification MakeClassification()
        => new SalariedClassification(_salary);

    protected override IPaymentSchedule MakeSchedule()
        => new MonthlySchedule();
}