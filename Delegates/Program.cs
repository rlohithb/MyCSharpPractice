using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Delegates
{
    public delegate void MyDelegate(string Message);
    public delegate void SampleDelegate();
    public delegate int SampleReturnDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            //A delegate is a type safe function pointer.

            MyDelegate myDelegate = new MyDelegate(MyFunc);
            myDelegate("Hello from the MyFunc method Lohith....");

            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID = 1, Name = "Mary", Salary = 5000, Experience = 5 });
            empList.Add(new Employee() { ID = 2, Name = "John", Salary = 9000, Experience = 8 });
            empList.Add(new Employee() { ID = 3, Name = "Rachel", Salary = 3500, Experience = 2 });
            empList.Add(new Employee() { ID = 4, Name = "Mariesa", Salary = 7000, Experience = 7 });
            empList.Add(new Employee() { ID = 5, Name = "Burt", Salary = 4200, Experience = 3 });
            empList.Add(new Employee() { ID = 6, Name = "George", Salary = 6000, Experience = 6 });

            IsPromotable isPromotable = new IsPromotable(Promote);

            Console.WriteLine("********Promoting by Experience*********");
            //Passing delegate function as a parameter
            Employee.PromoteEmployee(empList, isPromotable);

            Console.WriteLine("********Promoting by Salary*********");
            //Passing delegate function as a lambda function
            Employee.PromoteEmployee(empList, emp => emp.Salary > 4500);

            Console.WriteLine("***********Multi-cast delegates*********");
            //Multi-cast delegates: A delegate that points to more than 1 delegate.
            SampleDelegate del1, del2, del3, del4;
            del1 = new SampleDelegate(SampleOne);
            del2 = new SampleDelegate(SampleTwo);
            del3 = new SampleDelegate(SampleThree);
            del4 = del1 + del2 + del3 - del2;//delegate 4 is pointing to all 3 methods

            del4.Invoke();

            Console.WriteLine("***Multi-cast delegates other way****");
            SampleDelegate sd = new SampleDelegate(SampleOne);
            sd += SampleTwo;
            sd += SampleThree;
            sd -= SampleOne;
            sd();

            Console.WriteLine("*****Sample int return delegate******");
            SampleReturnDelegate srd = new SampleReturnDelegate(SampleReturnOne);
            srd += SampleReturnTwo;//Returns the last value.

            int retVal = srd();

            Console.WriteLine("Returned value from SampleReturn: " + retVal);
            Console.ReadKey();
        }
        public static void MyFunc(string strMessage)
        {
            Console.WriteLine(strMessage);
        }
        public static bool Promote(Employee emp)
        {
            if (emp.Experience >= 5)
                return true;
            return false;
        }
        public static void SampleOne()
        {
            Console.WriteLine("Sample ONE invoked");
        }
        public static void SampleTwo()
        {
            Console.WriteLine("Sample TWO invoked");
        }
        public static void SampleThree()
        {
            Console.WriteLine("Sample Three invoked");
        }
        public static int SampleReturnOne()
        {
            return 1;
        }
        public static int SampleReturnTwo()
        {
            return 2;
        }
    }

    delegate bool IsPromotable(Employee emp);

    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }

        public static void PromoteEmployee(List<Employee> employees,
            IsPromotable isEligibleForPromotion)
        {
            foreach (Employee employee in employees)
            {
                if (isEligibleForPromotion(employee))
                    Console.WriteLine(employee.Name + " is promoted");
            }
        }
    }
}
