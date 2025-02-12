using Payroll.Application.Contracts.Affiliations;
using Payroll.Application.Contracts.Methods;
using Payroll.Core.Contracts;
using Payroll.Core.Entities;
using Payroll.Infrastructure.Data;

namespace Payroll.Transactions.Base;

public abstract class AddEmployeeTransaction(int empId, string name, string address)
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

        Employee e = new(empId, name, address)
        {
            Affiliation = aff,
            Classification = pc,
            Schedule = ps,
            Method = pm
        };

        PayrollDb.AddEmployee(empId, e);
    }
}