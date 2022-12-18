using System;
namespace Lesson3;

public abstract class BaseEmployee
{
    protected string Name { get; set; }
    protected string SecondName { get; set; }

    protected string[] FirstNames = { "Александр", "Сергей", "Евгений", "Влад", "Вадим" };
    protected string[] SecondNames = { "Штефан", "Малыгин", "Приходько", "Поляков", "Вебер" };

    public abstract decimal Salary(decimal salary);
    public abstract void GetInfoEmployee();

}

