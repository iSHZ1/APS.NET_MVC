using System;
namespace Lesson3;

public class Employee : BaseEmployee
{
    private readonly Random random = new Random();
    private decimal _salary;

    public Employee()
	{
        Name = FirstNames[random.Next(0, 4)];
        SecondName = SecondNames[random.Next(0, 4)];

        Salary(random.Next(20000, 30000));
    }

    public override void GetInfoEmployee()
    {
        Console.WriteLine($"Имя сотрудника:{Name}  " +
            $" Фамилия сотрудника:{SecondName}   " +
            $"Зарплата за месяц:{_salary}");
    }

    public override decimal Salary(decimal salary)
    {
        return _salary = salary;
    }
}

