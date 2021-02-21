using System;
using System.Collections.Generic;

namespace LambdaFuncActionPredicate
{
    
    class Program
    {
        delegate double PropDelegate(int radius);
        static PropDelegate pd = new PropDelegate(CalculateArea);
        static void Main(string[] args)
        {
            Console.WriteLine("*****By calling the Calculate Area********");
            var arByMethod = pd.Invoke(20);
            Console.WriteLine("Area by Method: " + arByMethod);

            Console.WriteLine("*******Anonymous Functions***********");
            PropDelegate anonymousFunction = new PropDelegate(
                                                    delegate (int r)
                                                    {
                                                        return 3.14 * r * r;
                                                    });
            var arByAnonymousMethod = anonymousFunction.Invoke(20);
            Console.WriteLine("Area by Anonymous Function: " + arByAnonymousMethod);

            Console.WriteLine("*************Lambda Function*************");
            PropDelegate lambdaFunction = r => 3.14 * r * r;
            var lambdaFuncArea = lambdaFunction.Invoke(20);
            Console.WriteLine("Area by Lambda: " + lambdaFuncArea);

            Console.WriteLine("*****Lambda+Func********");
            Func<Double, Double> funcPointer = r => 3.14 * r * r;
            double funcArea = funcPointer(20);
            Console.WriteLine("Area by Func delegate: " + funcArea);

            Console.WriteLine("*****Action Delegate*****");
            Action<string> MyAction = y => Console.Write(y);
            MyAction("Hello");

            Console.WriteLine("*********Predicate delegate*******");
            Predicate<string> CheckGreaterThan5 = x => x.Length > 5;
            Console.WriteLine(CheckGreaterThan5("lohith2398742934487"));


            List<string> myString = new List<string>();
            myString.Add("Lohith");
            myString.Add("Shravya");
            myString.Add("Lohi");

            string str = myString.Find(CheckGreaterThan5);

            Console.WriteLine(str);

            Console.ReadKey();
        }
        static double CalculateArea(int r)
        {
            return 3.14 * r * r;
        }

    }
}
