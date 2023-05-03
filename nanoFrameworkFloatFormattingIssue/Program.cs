using System;
using System.Diagnostics;
using System.Threading;

namespace nanoFrameworkFloatFormattingIssue
{
    public class Program
    {
        public static void Main()
        {
            // On .NET4.8 the following yields:
            //
            // 1.2345E-09
            // 1.2345E-09
            // 1.23450E-009
            // 1.23450E-009
            //
            // On nF yields:
            //
            // 0
            // 0
            // E5
            // E5

            double value = 1.2345e-9;

            Debug.WriteLine(value.ToString());
            Debug.WriteLine($"{value}");
            Debug.WriteLine(value.ToString("E5"));
            Debug.WriteLine($"{value:E5}");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
