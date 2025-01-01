using Bogus;
using Payroll.Application.Transactions.Add;
using TestUtilities.Models.Employee;

namespace TestUtilities.Mocks.Employee;

public static class EmployeeMockFactory
{
    private static readonly Faker _faker = new();
    private static (int, string, string) GetTransactionBaseData()
    {
        var id = _faker.Random.Number(1, 100);
        var name = _faker.Name.FirstName();
        var address = "Home";

        return (id, name, address);
    }
    public static (AddSalariedEmployee, ExpectedSalaried) CreateSalariedMock()
    {
        var fake = new Faker<AddSalariedEmployee>();

        var (id, name, address) = GetTransactionBaseData();
        var salary = Convert.ToDouble(_faker.Finance.Amount(1000.0m, 2500.0m));

        var transaction = fake.CustomInstantiator((f) => 
            new AddSalariedEmployee(id, name, address, salary));

        return (transaction, new(id, name, address, salary));
    }
}