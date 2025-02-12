namespace Payroll.Core.Contracts;

/// <summary>
/// Represents a transaction of command line
/// </summary>
public interface ITransaction
{
    public void Execute();
}