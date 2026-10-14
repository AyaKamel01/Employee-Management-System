
using System;
using System.Collections.Generic;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
}

class Program
{
    static List<Employee> employees = new List<Employee>();
    static int nextId = 1;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Employee Management System ===");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View Employees");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;

                case "2":
                    ViewEmployees();
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void AddEmployee()
    {
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine();

        Console.Write("Enter department: ");
        string department = Console.ReadLine();

        Console.Write("Enter salary: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal salary)
            || salary < 0)
        {
            Console.WriteLine("Please enter a valid salary.");
            return;
        }

        Employee employee = new Employee
        {
            Id = nextId++,
            Name = name,
            Department = department,
            Salary = salary
        };

        employees.Add(employee);

        Console.WriteLine("Employee added successfully!");
    }

    static void ViewEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        Console.WriteLine("\n--- Employees List ---");

        foreach (Employee employee in employees)
        {
            Console.WriteLine(
                $"ID: {employee.Id} | " +
                $"Name: {employee.Name} | " +
                $"Department: {employee.Department} | " +
                $"Salary: {employee.Salary}"
            );
        }
    }
}
