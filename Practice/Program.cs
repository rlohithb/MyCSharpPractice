using System;
using System.Threading;

namespace Practice
{
    class Maths
    {
        public int Num1;
        public int Num2;

        Random o = new Random();

        public void Divide()
        {
            object _lock = new object();
            for (long i = 0; i < 100000; i++)
            {
                /* Using lock
                lock(this)//Only 1 thread can execute this code at a time
                { 
                    Num1 = o.Next(1, 2);//returns a random num between 1 and 2
                    Num2 = o.Next(1, 2);//returns a random num between 1 and 2
                    int result = Num1 / Num2;
                    Console.WriteLine("Result: {0}", result);
                    Num1 = 0;//set to 0
                    Num2 = 0;//set to
                }
                */
                //Using Monitor instead of lock
                Monitor.Enter(_lock);
                Num1 = o.Next(1, 2);//returns a random num between 1 and 2
                Num2 = o.Next(1, 2);//returns a random num between 1 and 2
                int result = Num1 / Num2;
                Console.WriteLine("Result: {0}", result);
                Num1 = 0;//set to 0
                Num2 = 0;//set to
                Monitor.Exit(_lock);
            }
        }
    }

    class Program
    {
        static Maths objMaths = new Maths();
        static void Main(string[] args)
        {
            #region PARALLEL PROGRAMMING. THREADS
            /* Thread Basics
            Thread t1 = new Thread(new ThreadStart(Fun1));//starts executing first fun
            Thread t2 = new Thread(new ThreadStart(Fun2));//starts executing second fun

            t1.Start();
            t2.Start();

            */

            //Thread safety
            Thread t1 = new Thread(objMaths.Divide);

            //Calling Divide function at the same time from 2 threads
            t1.Start();//Child thread

            objMaths.Divide(); //Main thread
            #endregion

            #region SEQUENTIAL PROGRAMMING. TIME CONSUMING
            /*
            //Sequential. Takes lot of time
            Fun1();
            Fun2();
            */
            #endregion


            Console.WriteLine("Hello World!");
        }
        static void Fun1()
        {
            for (int i = 0; i < 100000; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(@"Fun 1: - {0}",i);
            }
        }
        static void Fun2()
        {
            for (int i = 0; i < 100000; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(@"Fun 2: - {0}", i);
            }
        }
    }
}
