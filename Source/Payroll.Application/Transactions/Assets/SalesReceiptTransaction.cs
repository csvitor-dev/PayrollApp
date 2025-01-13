using Payroll.Application.Contracts.Classifications;
using Payroll.Core.Entities;
using Payroll.Infrastructure.Data;

namespace Payroll.Application.Transactions.Assets;

public class SalesReceiptTransaction(int id, DateTime date, double amount) : ITransaction
{
    public void Execute()
    {
        Employee? e = PayrollDb.GetEmployee(id);
        
        if (e is null) 
            throw new InvalidOperationException("Employee not found");
        
        if (e.Classification is not CommissionedClassification cc)
            throw new InvalidOperationException("Classification is not commissioned");
        cc.AddSalesReceipt(new(date, amount));
    }
}