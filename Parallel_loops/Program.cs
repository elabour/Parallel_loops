using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[100];
            // Initialize the array with some data

            Stopwatch sw=new Stopwatch();
            sw.Start();
            // Sequential for loop
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i * 2;
            }
            sw.Stop();
            Console.WriteLine(" For loop completed, Ellapsed time:" + sw.ElapsedMilliseconds.ToString());
            // Parallel for loop
            sw.Reset();
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = Environment.ProcessorCount;

            sw.Start();
            Parallel.For(0, data.Length,options, i =>
            {
                data[i] = data[i] * 2;
            });

            sw.Stop();
            Console.WriteLine("Parallel For loop completed, Ellapsed time:" + sw.ElapsedMilliseconds.ToString());

            // Perform further processing or print the results
            // ...

            Console.ReadLine();


        }
    }
}
