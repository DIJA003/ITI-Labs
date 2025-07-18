using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Lab3_Employee
{


   
    internal class MainClass
    {

        static void Main(string[] args)
        {

            int currCount = 0;
            Employee[] employee = new Employee[200];

            while (true) 
            {

                Console.WriteLine("Please write the number of the operaiton you want \n1-Add an Employee \n2-Get all Employees " +
                "\n3-Update Employee \n4-Get Employee info by ID");
                int op_number = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (op_number)
                {
                    case 1:
                        if (currCount < 200)
                        {
                            addEmployee(employee, currCount);
                            currCount++;
                            Console.WriteLine("Employee add successfully, Press Enter to continue");
                        }
                        else
                        {
                            Console.WriteLine("Limit of Employees reached, Press Enter to continue");
                        }
                        break;

                    case 2:
                        if (currCount > 0) getAllEmployee(employee, currCount);
                        else Console.WriteLine("There is no employee recorded, Press Enter to continue");
                        break;

                    case 3:
                        if (currCount > 0)
                        {
                            Console.Write("Please Enter Employee's ID: ");
                            int employeeID = int.Parse(Console.ReadLine());
                            updateEmployee(employee, currCount, employeeID);

                        }
                        else Console.WriteLine("There is no employee recorded, Press Enter to continue");
                        break;

                    case 4:
                        if (currCount > 0)
                        {
                            Console.Write("Enter Employee's ID: ");
                            int index = findEmployeeByID(employee, currCount, int.Parse(Console.ReadLine()));
                            employee[index].info();
                        }
                        else Console.WriteLine("There is no employee recorded, Press Enter to continue");
                        break;

                    default:
                        Console.WriteLine("Invalid number");
                        break;

                }
                Console.ReadKey();
                Console.Clear();


            }

        }

        public static void addEmployee(Employee[] employee, int index)
        {
            Console.Write($"Enter employee no {index + 1} ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write($"Enter employee no {index + 1} Name: ");
            string name = Console.ReadLine();
            Console.Write($"Enter employee no {index + 1} Salary: ");
            double salary = double.Parse(Console.ReadLine());
            employee[index] = new(id, name, salary);
        }
        public static void getAllEmployee(Employee[] employee, int size)
        {
            for (int i = 0; i < size; i++)
            {
                employee[i].info();
            }
        }
        public static void updateEmployee(Employee[] employee, int size, int id)
        {
            int index = findEmployeeByID(employee, size, id);
            if (index == -1) return;
            Console.Clear();

            Console.WriteLine("-----Select which to update-----");
            Console.WriteLine("1-Update name \n2-Update salary " +
                "\n3-Update all Employee's details");
            int op_number = int.Parse(Console.ReadLine());
            switch (op_number) 
            {
                case 1:
                    updateEmployeeName(employee,index);
                    break;
                case 2:
                    updateEmployeeSalary(employee,index);
                    break;
                case 3: 
                    updateAllEmployeeDetail(employee, index);
                    break;
            }
        }
        public static void updateEmployeeName(Employee[] employee, int index)
        {
            Console.Clear();
            Console.Write("Enter the new name: ");
            employee[index].setName(Console.ReadLine());
            Console.WriteLine("Name updated successfully, Press Enter to continue");
            Console.Clear();

        }
        public static void updateEmployeeSalary(Employee[] employee, int index)
        {
            Console.Clear();
            Console.Write("Enter the new salary: ");
            employee[index].setSalary(double.Parse(Console.ReadLine()));
            Console.Clear();
            Console.WriteLine("Salary updated successfully, Press Enter to continue");
            
        }
        public static void updateAllEmployeeDetail(Employee[]employee,int index)
        {
            Console.Clear();
            Console.Write("Enter the Employee's new name: ");
            employee[index].setName(Console.ReadLine());
            Console.Write("Enter the Employee's new salary: ");
            employee[index].setSalary(double.Parse(Console.ReadLine()));
            Console.Clear();
            Console.WriteLine($"All Employee details updated successfully, Press Enter to continue");
        }
        public static int findEmployeeByID(Employee[] employee, int size,int id) 
        {
            int index = -1;
            for (int i = 0; i < size; i++)
            {

                if (employee[i].getID() == id)
                {
                    index = i;
                    break;
                }
            }
            return index;

        }
    }
}
