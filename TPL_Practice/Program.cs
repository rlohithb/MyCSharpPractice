using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_Practice
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /*
            //Tasks do not have thread affinity. Use TPL instead of threading
            //in C#
            Task t1 = new Task(Fun1);
            Task t2 = new Task(Fun2);
            t1.Start();
            t2.Start();
            */
            Fun1();
            Fun2();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
        static async void Fun1()
        {
            for (int i = 0; i < 100000; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine(@"Fun 1: - {0}", i);
            }
        }
        static async void Fun2()
        {
            for (int i = 0; i < 100000; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine(@"Fun 2: - {0}", i);
            }
        }
    }
}
