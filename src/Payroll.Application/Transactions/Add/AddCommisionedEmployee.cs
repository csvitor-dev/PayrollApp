using Payroll.Core.Contracts;
using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;

namespace Payroll.Application.Transactions.Add;

public class AddCommissionedEmployee
    (int id, string name, string address, double salary, double commissionRate) 
    : AddEmployeeTransaction(id, name, address)
{
    private readonly double _salary = salary;
    private readonly double _commissionedRate = commissionRate;

    protected override IPaymentClassification MakeClassification()
        => new CommissionedClassification(_salary, _commissionedRate);

    protected override IPaymentSchedule MakeSchedule()
        => new BiweeklySchedule();
}