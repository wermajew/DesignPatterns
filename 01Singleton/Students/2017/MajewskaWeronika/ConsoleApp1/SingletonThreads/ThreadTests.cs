using SingletonThreadSafe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonThreads
{
    class ThreadTests
    {
        static void Main(string[] args)
        {
            // Multithreading testss
            ThreadingTestSingletonNonThreadSafe();
            ThreadingTestSingletonThreadSafe();


            // Measuring Invocation Time
            var threadSafeTime = MeasureElapsedTimeOfGetInstanceInvocation(true);
            Console.WriteLine($"Elapsed time [THREAD-SAFE] = {threadSafeTime.ElapsedMilliseconds} [ms] " +
                $"that is {threadSafeTime.ElapsedTicks} ticks\n\n");

            var nonThreadSafeTime = MeasureElapsedTimeOfGetInstanceInvocation(false);
            Console.WriteLine($"Elapsed time [NON-SAFE] = {nonThreadSafeTime.ElapsedMilliseconds} [ms] " +
                $"that is {nonThreadSafeTime.ElapsedTicks} ticks\n\n");
        }


        private static void ThreadingTestSingletonNonThreadSafe()
        {

            var taskAccessingSingleton = Enumerable.Range(0, 10)
                .Select(t => Task<Singleton>.Factory.StartNew(() => Singleton.GetInstance())).ToArray<Task>();

            Task.WaitAll(taskAccessingSingleton);
            Console.WriteLine($"Number of instances created by tasks = {Singleton.InstanceCounter}\n\n\n");

        }

        private static void ThreadingTestSingletonThreadSafe()
        {

            var taskAccessingSingleton = Enumerable.Range(0, 10)
                .Select(t => Task<SingletonThreadingSafe>.Factory.StartNew(() => SingletonThreadingSafe.GetInstance())).ToArray<Task>();

            Task.WaitAll(taskAccessingSingleton);
            Console.WriteLine($"Number of instances created by tasks = {SingletonThreadingSafe.InstanceCounter}\n\n\n");

        }

        private static Stopwatch MeasureElapsedTimeOfGetInstanceInvocation(bool ifThreadSafe)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                if (ifThreadSafe)
                {
                    var testObject = SingletonThreadingSafe.GetInstance();
                }
                else
                {
                    var testObject = Singleton.GetInstance();
                }
            }
            watch.Stop();
            var time = watch.ElapsedMilliseconds;
            return watch;
        }
    }
}
