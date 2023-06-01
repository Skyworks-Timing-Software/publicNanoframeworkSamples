using System;
using System.Diagnostics;
using System.Threading;

namespace nanoFrameworkExceptionTesting
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello from nanoFramework!");

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            byte[] dummyArray = new byte[10];

            try
            {
                // throw Exception
                Console.WriteLine($"{dummyArray[1_000]}");
            }
            catch
            {
                // empty on purpose
            }

            stopWatch.Stop();

            Console.WriteLine($"Exception took {stopWatch.ElapsedMilliseconds}ms");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
