using System;
using System.Collections.Generic;

namespace Workloom
{
    // Step 1: Create Employee Class
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public Employee(int id, string name, string position)
        {
            Id = id;
            Name = name;
            Position = position;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Position: {Position}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int employeeIdCounter = 1; // Unique ID generator
            List<Employee> employees = new List<Employee>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Workloom: Employee Record System =====");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Edit Employee");
                Console.WriteLine("5. Search Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add Employee
                        Console.Write("\nEnter Employee Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Employee Position: ");
                        string position = Console.ReadLine();

                        Employee newEmployee = new Employee(employeeIdCounter++, name, position);
                        employees.Add(newEmployee);

                        Console.WriteLine($"Employee added successfully! Assigned ID: {newEmployee.Id}");
                        break;

                    case "2":
                        // View Employees
                        Console.WriteLine("\n==== Employee List ====");
                        if (employees.Count == 0)
                            Console.WriteLine("No employees found.");
                        else
                            employees.ForEach(emp => Console.WriteLine(emp));
                        break;

                    case "3":
                        // Delete Employee
                        Console.Write("\nEnter Employee ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            Employee employeeToRemove = employees.Find(emp => emp.Id == deleteId);
                            if (employeeToRemove != null)
                            {
                                employees.Remove(employeeToRemove);
                                Console.WriteLine("Employee deleted successfully!");
                            }
                            else
                                Console.WriteLine("Employee not found.");
                        }
                        else
                            Console.WriteLine("Invalid ID format.");
                        break;

                    case "4":
                        // Edit Employee
                        Console.Write("\nEnter Employee ID to edit: ");
                        if (int.TryParse(Console.ReadLine(), out int editId))
                        {
                            Employee employeeToEdit = employees.Find(emp => emp.Id == editId);
                            if (employeeToEdit != null)
                            {
                                Console.Write($"Enter new name for {employeeToEdit.Name} (or press Enter to keep unchanged): ");
                                string newName = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(newName))
                                    employeeToEdit.Name = newName;

                                Console.Write($"Enter new position for {employeeToEdit.Position} (or press Enter to keep unchanged): ");
                                string newPosition = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(newPosition))
                                    employeeToEdit.Position = newPosition;

                                Console.WriteLine("Employee details updated successfully!");
                            }
                            else
                                Console.WriteLine("Employee not found.");
                        }
                        else
                            Console.WriteLine("Invalid ID format.");
                        break;

                    case "5":
                        // Search Employee
                        Console.Write("\nEnter Employee Name to search: ");
                        string searchName = Console.ReadLine().ToLower();

                        var foundEmployees = employees.FindAll(emp => emp.Name.ToLower().Contains(searchName));

                        Console.WriteLine("\n==== Search Results ====");
                        if (foundEmployees.Count > 0)
                            foundEmployees.ForEach(emp => Console.WriteLine(emp));
                        else
                            Console.WriteLine("❌ No matching employees found.");
                        break;

                    case "6":
                        // Exit
                        Console.WriteLine("\nExiting Workloom Employee Record System...");
                        return;

                    default:
                        Console.WriteLine("❌ Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
