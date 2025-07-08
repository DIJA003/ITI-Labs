namespace Lab2_EmployeeData
{
    internal class EmployeeData
    {
        static void Main(string[] args)
        {
            int id, age, salary;
            string name;
            do
            {
                Console.Write("Enter ID: ");
                id = int.Parse(Console.ReadLine());
                if (id <= 0) Console.WriteLine("Invalid ID, Please enter a positive number.");

            } while (id <= 0);

            bool hasDigit;

            do
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine();
                hasDigit = false;
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i] >= '0' && name[i] <= '9')
                    {
                        hasDigit = true;
                        break;
                    }
                }
                if (hasDigit || name.Length == 0) Console.WriteLine("Invalid Name, must not contain Digits");

            } while (hasDigit || name.Length == 0);

            do
            {
                Console.Write("Enter Age: ");
                age = int.Parse(Console.ReadLine());
                if (age <= 0) Console.WriteLine("Invalid Age, Please enter a positive number.");
            } while (age <= 0);
            do
            {
                Console.Write("Enter Salary: ");
                salary = int.Parse(Console.ReadLine());
                if (salary <= 0) Console.WriteLine("Invalid Salary, Please enter a positive number.");
            } while (salary <= 0);

            Console.WriteLine($"------INFO------ \nID: {id} \nName: {name} \nAge: {age} \nSalary: {salary}");
        }
    }
}
