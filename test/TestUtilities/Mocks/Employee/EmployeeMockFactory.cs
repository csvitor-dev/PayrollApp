using Bogus;
using Payroll.Application.Transactions.Add;
using TestUtilities.Models.Employee;

namespace TestUtilities.Mocks.Employee;

public static class EmployeeMockFactory
{
    private static readonly Faker Faker = new();
    private static int MaxId { get; set; } = Faker.Random.Number(1, 1_000);
	
    private static (int, string, string) GetTransactionBaseData()
    {
        var id = MaxId++;
        var name = Faker.Name.FirstName();
        var address = "Home";

        return (id, name, address);
    }

    public static (AddSalariedEmployee, ExpectedSalaried) CreateSalariedMock()
    {
        var fake = new Faker<AddSalariedEmployee>();

        var (id, name, address) = GetTransactionBaseData();
        var salary = Convert.ToDouble(Faker.Finance.Amount(1000.0m, 2500.0m));

        var transaction = fake.CustomInstantiator(_ =>
            new AddSalariedEmployee(id, name, address, salary));

        return (transaction, new(id, name, address, salary));
    }

    public static (AddHourlyEmployee, ExpectedHourly) CreateHourlyMock()
    {
        var fake = new Faker<AddHourlyEmployee>();

        var (id, name, address) = GetTransactionBaseData();
        var rate = Convert.ToDouble(Faker.Finance.Amount(1.0m, 100.0m));

        var transaction = fake.CustomInstantiator(_ =>
            new AddHourlyEmployee(id, name, address, rate));

        return (transaction, new(id, name, address, rate));
    }

    public static (AddCommissionedEmployee, ExpectedCommissioned) CreateCommissionedMock()
    {
        var fake = new Faker<AddCommissionedEmployee>();

        var (id, name, address) = GetTransactionBaseData();
        var salary = Convert.ToDouble(Faker.Finance.Amount(1000.0m, 2500.0m));
        var rate = Convert.ToDouble(Faker.Finance.Amount(1.0m, 100.0m));

        var transaction = fake.CustomInstantiator(_ =>
            new AddCommissionedEmployee(id, name, address, salary, rate));

        return (transaction, new(id, name, address, salary, rate));
    }
}
