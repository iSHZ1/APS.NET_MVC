using System;
namespace Lesson3;

public static class FreelancerBuilder
{
    public static void NewSalaty(this Freelancer freelancer, decimal salary)
    {
        freelancer.Salary(salary);
    }
}