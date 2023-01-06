namespace Lesson3;

class Program
{
    static void Main()
    {
        //List<Employee> Employees = new List<Employee>();
        //List<Freelancer> freelancers = new List<Freelancer>();

        //GenerateEmployee(Employees);
        //GenerateFreelancer(freelancers);

        //foreach (var item in Employees)
        //    item.GetInfoEmployee();

        //freelancers[0].NewSalaty(100);
        //freelancers[0].GetInfoEmployee();

    }

    private static void GenerateEmployee(List<Employee> Employees)
    {
        for (int i = 0; i < 5; i++)
            Employees.Add(new Employee());
    }

    private static void GenerateFreelancer(List<Freelancer> freelancers)
    {
        for (int i = 0; i < 5; i++)
            freelancers.Add(new Freelancer());
        
    }


}

