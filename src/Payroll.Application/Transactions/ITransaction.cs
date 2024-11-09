namespace Payroll.Application.Transactions;

/// <summary>
/// Represents a transaction of command line
/// </summary>
public interface ITransaction
{
    public void Execute();
}