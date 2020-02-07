using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Capitulo1
{
    class OverdraftAccount
    {
        const int NUMBER_OF_ITERATIONS = 32;
        public void RunTasksCorrected()
        {
            double result = 0d;
            Task<double>[] tasks = new Task<double>[NUMBER_OF_ITERATIONS];
            // We create one task per iteration.

            for (int i = 0; i < NUMBER_OF_ITERATIONS; i++)
            {
                tasks[i] = Task.Run(() => DoIntensiveCalculations());
            }

            // We wait for the tasks to finish
            Task.WaitAll(tasks);
            // We collect the results
            foreach (var task in tasks)
            {
                result += task.Result;
            }
            // Print the result
            Console.WriteLine("");
            Console.WriteLine("The result is {0}", result);
        }

        public double DoIntensiveCalculations()
        {
            double result = 10000d;
            var maxValue = Int32.MaxValue >> 4;

            for (int i = 1; i < maxValue; i++)
            {
                if (i % 2 == 0)
                {
                    result /= i;
                }
                else
                {
                    result *= i;
                }
            }
            return result;
        }

        public void PrintPercentageResult()
        {
            Console.WriteLine("Introduce a decimal amount1:");
            var amount1 = Console.ReadLine();
            Console.WriteLine("Introduce a decimal amount2:");
            var amount2 = Console.ReadLine();

            var result = this.PercentageChangeAsync(decimal.Parse(amount1), decimal.Parse(amount2));
            Console.WriteLine("This is the result: {0}", result.Result);
        }

        public async Task<decimal> PercentageChangeAsync(decimal mount1, decimal mount2)
        {
            var result = await Task.Run(
                                        () => {
                                                 return (mount2 - mount1) / mount1;
                                              }
                                       );

            return result * 100;
        }

        public void BarriersUsage()
        {
            var participants = 5;
            var barrier = new Barrier( participants + 1, b => {
                Console.WriteLine("{0} participants are at rendez-vous point {1}.", b.ParticipantCount - 1, b.CurrentPhaseNumber);
            });

            for (int i = 0; i < participants; i++)
            {
                var localCopy = i;

                Task.Run(() => {

                    Console.WriteLine("Task {0} left point A!", localCopy);
                    Thread.Sleep(1000 * localCopy + 1); // Do some "work"

                    if (localCopy % 2 == 0)
                    {
                        Console.WriteLine("Task {0} arrived at point B!", localCopy);
                        barrier.SignalAndWait();
                    }
                    else
                    {
                        Console.WriteLine("Task {0} changed its mind and went back!", localCopy);
                        barrier.RemoveParticipant();
                        return;
                    }

                    Thread.Sleep(1000 * (participants - localCopy)); // Do some "more work"
                    Console.WriteLine("Task {0} arrived at point C!", localCopy);
                    barrier.SignalAndWait();
                });
            }

            Console.WriteLine("Main thread is waiting for {0} tasks!", barrier.ParticipantCount - 1);
            barrier.SignalAndWait(); // Waiting at the first phase
            barrier.SignalAndWait(); // Waiting at the second phase
            Console.WriteLine("Main thread is done!");
        }


    }
    internal class SyncResource
    {
        // Use a monitor to enforce synchronization.
        public void Access()
        {
            lock (this)
            {
                Console.WriteLine("Starting synchronized resource access on thread #{0}", Thread.CurrentThread.ManagedThreadId);

                if (Thread.CurrentThread.ManagedThreadId % 2 == 0)
                    Thread.Sleep(2000);

                Thread.Sleep(200);
                Console.WriteLine("Stopping synchronized resource access on thread #{0}", Thread.CurrentThread.ManagedThreadId);
            }
        }
    }

    internal class UnSyncResource
    {
        // Do not enforce synchronization.
        public void Access()
        {
            Console.WriteLine("Starting unsynchronized resource access on Thread #{0}", Thread.CurrentThread.ManagedThreadId);

            if (Thread.CurrentThread.ManagedThreadId % 2 == 0)
                Thread.Sleep(2000);

            Thread.Sleep(200);
            Console.WriteLine("Stopping unsynchronized resource access on thread #{0}", Thread.CurrentThread.ManagedThreadId);
        }
    }

    public class App
    {
        private static int numOps;
        private static AutoResetEvent opsAreDone = new AutoResetEvent(false);
        private static SyncResource SyncRes = new SyncResource();
        private static UnSyncResource UnSyncRes = new UnSyncResource();

        public static void MainP()
        {
            // Set the number of synchronized calls.
            numOps = 5;
            for (int ctr = 0; ctr <= 4; ctr++)
                ThreadPool.QueueUserWorkItem(new WaitCallback(SyncUpdateResource));

            // Wait until this WaitHandle is signaled.
            opsAreDone.WaitOne();
            Console.WriteLine("\t\nAll synchronized operations have completed.\n");

            // Reset the count for unsynchronized calls.
            numOps = 5;
            for (int ctr = 0; ctr <= 4; ctr++)
                ThreadPool.QueueUserWorkItem(new WaitCallback(UnSyncUpdateResource));

            // Wait until this WaitHandle is signaled.
            opsAreDone.WaitOne();
            Console.WriteLine("\t\nAll unsynchronized thread operations have completed.\n");
        }

        static void SyncUpdateResource(Object state)
        {
            // Call the internal synchronized method.
            SyncRes.Access();

            // Ensure that only one thread can decrement the counter at a time.
            if (Interlocked.Decrement(ref numOps) == 0)
                // Announce to Main that in fact all thread calls are done.
                opsAreDone.Set();
        }

        static void UnSyncUpdateResource(Object state)
        {
            // Call the unsynchronized method.
            UnSyncRes.Access();

            // Ensure that only one thread can decrement the counter at a time.
            if (Interlocked.Decrement(ref numOps) == 0)
                // Announce to Main that in fact all thread calls are done.
                opsAreDone.Set();
        }
    }
    // The example displays output like the following:
    //    Starting synchronized resource access on thread #6
    //    Stopping synchronized resource access on thread #6
    //    Starting synchronized resource access on thread #7
    //    Stopping synchronized resource access on thread #7
    //    Starting synchronized resource access on thread #3
    //    Stopping synchronized resource access on thread #3
    //    Starting synchronized resource access on thread #4
    //    Stopping synchronized resource access on thread #4
    //    Starting synchronized resource access on thread #5
    //    Stopping synchronized resource access on thread #5
    //
    //    All synchronized operations have completed.
    //
    //    Starting unsynchronized resource access on Thread #7
    //    Starting unsynchronized resource access on Thread #9
    //    Starting unsynchronized resource access on Thread #10
    //    Starting unsynchronized resource access on Thread #6
    //    Starting unsynchronized resource access on Thread #3
    //    Stopping unsynchronized resource access on thread #7
    //    Stopping unsynchronized resource access on thread #9
    //    Stopping unsynchronized resource access on thread #3
    //    Stopping unsynchronized resource access on thread #10
    //    Stopping unsynchronized resource access on thread #6
    //
    //    All unsynchronized thread operations have completed.
}
