using Payroll.Application.Transactions.Assets;

namespace TestUtilities.Mocks.Assets;

public static class TimeCardTransactionMockFactory
{
    public static TimeCardTransaction CreateMock(double hours)
    {
        return new TimeCardTransaction(1, new DateTime(2020, 1, 9), hours);
    }
}