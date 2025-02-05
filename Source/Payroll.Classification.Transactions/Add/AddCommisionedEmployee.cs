using Payroll.Classifications.Contracts;
using Payroll.Core.Contracts;
using Payroll.Schedules.Contracts;
using Payroll.Transactions.Base;

namespace Payroll.Classification.Transactions.Add;

public class AddCommissionedEmployee
    (int id, string name, string address, double salary, double commissionRate) 
    : AddEmployeeTransaction(id, name, address)
{
    protected override IPaymentClassification MakeClassification()
        => new CommissionedClassification(salary, commissionRate);

    protected override IPaymentSchedule MakeSchedule()
        => new BiweeklySchedule();
}