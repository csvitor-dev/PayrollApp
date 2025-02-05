using Payroll.Classifications.Contracts;
using Payroll.Core.Contracts;
using Payroll.Schedules.Contracts;
using Payroll.Transactions.Base;

namespace Payroll.Classification.Transactions.Add;

public class AddSalariedEmployee
    (int id, string name, string address, double salary) 
    : AddEmployeeTransaction(id, name, address)
{
    protected override IPaymentClassification MakeClassification()
        => new SalariedClassification(salary);

    protected override IPaymentSchedule MakeSchedule()
        => new MonthlySchedule();
}