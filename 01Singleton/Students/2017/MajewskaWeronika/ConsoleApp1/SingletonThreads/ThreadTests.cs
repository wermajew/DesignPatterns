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
            Console.WriteLine($"Elapsed time [THREAD-SAFE] = {threadSafeTime.ElapsedMilliseconds} [ms] that is {threadSafeTime.ElapsedTicks} ticks\n\n");

            var nonThreadSafeTime = MeasureElapsedTimeOfGetInstanceInvocation(false);
            Console.WriteLine($"Elapsed time [NON-SAFE] = {nonThreadSafeTime.ElapsedMilliseconds} [ms] that is {nonThreadSafeTime.ElapsedTicks} ticks\n\n");
        }

        private static void ThreadingTestSingletonThreadSafe()
        {
            // 1000 taskow - pararell blalab task poll i wspolbiezne wywolanie - wystartuja razem
        }

        private static void ThreadingTestSingletonNonThreadSafe()
        {
            var thread1 = new Thread(() =>
            {
                SingletonThreadSafe.Singleton.GetInstance();

            });
            var thread2 = new Thread(() =>
            {
                SingletonThreadSafe.Singleton.GetInstance();

            });

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine("--------------" + SingletonThreadSafe.Singleton.InstanceCounter);
        }

        private static Stopwatch MeasureElapsedTimeOfGetInstanceInvocation(bool ifThreadSafe)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                if (ifThreadSafe)
                {
                    var testObject = SingletonThreadSafe.SingletonThreadSafe.GetInstance();
                }
                else
                {
                    var testObject = SingletonThreadSafe.Singleton.GetInstance();
                }
            }
            watch.Stop();
            var time = watch.ElapsedMilliseconds;
            return watch;
        }
    }
}
