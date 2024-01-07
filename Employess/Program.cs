using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    public class Solution
    {

        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            var companies = employees.Select(x => x.Company).Distinct().OrderBy(x => x);
            foreach (var company in companies)
            {
                var employee = employees.Where(x => x.Company == company);
                var arr = employee.Select(x => x.Age).ToArray();
                double avg = Queryable.Average(arr.AsQueryable());

                dictionary.Add(company, (int)Convert.ToInt64(avg));
            }

            return dictionary;

        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            var companies = employees.Select(x => x.Company).Distinct().OrderBy(x => x);
            foreach (var company in companies)
            {
                var employee = employees.Where(x => x.Company == company);
                int count = employee.Count();

                dictionary.Add(company, count);
            }

            return dictionary;
        }

        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            Dictionary<string, Employee> dictionary = new Dictionary<string, Employee>();
            var companies = employees.Select(x => x.Company).Distinct().OrderBy(x => x);
            foreach (var company in companies)
            {
                var employee = employees.Where(x => x.Company == company);
                int age = employee.Max(x => x.Age);
                Employee final = employee.Where(x => x.Age == age).First();

                dictionary.Add(company, final);
            }

            return dictionary;
        }

        public static void Main()
        {
            int countOfEmployees = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (int i = 0; i < countOfEmployees; i++)
            {
                string str = Console.ReadLine();
                string[] strArr = str.Split(' ');
                employees.Add(new Employee
                {
                    FirstName = strArr[0],
                    LastName = strArr[1],
                    Company = strArr[2],
                    Age = int.Parse(strArr[3])
                });
            }

            foreach (var emp in AverageAgeForEachCompany(employees))
            {
                Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in CountOfEmployeesForEachCompany(employees))
            {
                Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
            }

            foreach (var emp in OldestAgeForEachCompany(employees))
            {
                Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
            }
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}