using Payroll.Application.Contracts.Affiliations;
using Payroll.Core.Contracts;
using Payroll.Core.Data;
using Payroll.Core.Entities;
using Payroll.Application.Contracts.Classifications;

namespace Payroll.Application.Transactions.Add;

public abstract class AddEmployeeTransaction(int empID, string name, string address)
    : ITransaction
{
    protected abstract IPaymentClassification MakeClassification(); // FACTORY METHOD
    protected abstract IPaymentSchedule MakeSchedule(); // FACTORY METHOD

    public void Execute()
    {
        var pc = MakeClassification();
        var ps = MakeSchedule();
        IPaymentMethod pm = new HoldMethod();
        IAffiliation aff = new NoAffiliation();

        Employee e = new(empID, name, address)
        {
            Affiliation = aff,
            Classification = pc,
            Schedule = ps,
            Method = pm
        };

        PayrollDb.AddEmployee(empID, e);
    }
}