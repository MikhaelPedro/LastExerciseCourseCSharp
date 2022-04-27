using System;
using System.Collections.Generic;
using System.Text;

namespace LastExercise.Entities
{
    class Employee
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public Employee(string nome, string email, double salary)
        {
            Nome = nome;
            Email = email;
            Salary = salary;
        }
    }
}
