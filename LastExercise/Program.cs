using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using LastExercise.Entities;

namespace Course
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter salary: ");
            double limit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();
            Console.Write("Email of people whose salary is more than " + limit.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine();

            List<Employee> list = new List<Employee>();
            try
            { 
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                        list.Add(new Employee(name, email, salary));
                    }
                }
                var filter = list.Where(p => p.Salary >= limit).Select(p => p.Email);
            
                var sum = list.Where(obj => obj.Nome[0] == 'M').Sum(obj => obj.Salary);

                foreach (string email in filter)
                {
                    Console.WriteLine(email);
                }
                Console.WriteLine();
                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}