using System;
namespace Lesson3;

public static class EmployeeBuilder
{
    public static void NewSalaty(this Employee employee, decimal salary)
    {
        employee.Salary(salary);
    }
}

