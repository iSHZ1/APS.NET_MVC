using System;
namespace Lesson3;

public class Freelancer : BaseEmployee
{
    private readonly Random random = new Random();
    private decimal _salary;

    public Freelancer()
    {
        Name = FirstNames[random.Next(0, 4)];
        SecondName = SecondNames[random.Next(0, 4)];

        Salary(random.Next(5, 10));
    }

    public override void GetInfoEmployee()
    {
        Console.WriteLine($"Имя сотрудника:{Name}  " +
            $" Фамилия сотрудника:{SecondName}   " +
            $"Зарплата за месяц:{_salary}");
    }

    public override decimal Salary(decimal salary)
    {
        return _salary = (decimal)20.8 * 8 * salary;
    }
}

