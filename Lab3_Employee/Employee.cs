using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Employee
{
    internal class Employee
    {
        int id;
        string name;
        double salary;

        public Employee(int _id, string _name, double _salary)
        {
            id = _id;
            name = _name;
            salary = _salary;
        }
        public void info()
        {
            Console.WriteLine($"ID:{id}, Name: {name}, Salary: {salary}");
        }
        public void setID(int _id)
        {
            id = _id;
        }
        public void setName(string _name)
        {
            name = _name;
        }
        public void setSalary(double _salary)
        {
            salary = _salary;
        }
        public int getID()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }
        public double getSalary()
        {
            return salary;
        }
    }
}
