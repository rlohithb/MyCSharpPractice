using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> emp = new List<Employee>();
            emp.Add(new Employee { Name = "Lohith", Address = "India" });
            emp.Add(new Employee { Name = "Shravya", Address = "India" });
            emp.Add(new Employee { Name = "John", Address = "USA" });
            emp.Add(new Employee { Name = "Ricky", Address = "USA" });
            emp.Add(new Employee { Name = "Marty", Address = "Canada" });
            emp.Add(new Employee { Name = "Betty", Address = "Canada" });
            emp.Add(new Employee { Name = "Angel", Address = "Europe" });

            var filterEmp = from temp in emp
                            where temp.Address == "Europe"
                            select temp;
            foreach(var o in filterEmp)
                Console.WriteLine(o.Name);
            Console.ReadKey();
        }
    }
    public class Employee
    {
        public string Name;
        public string Address;
    }
}
