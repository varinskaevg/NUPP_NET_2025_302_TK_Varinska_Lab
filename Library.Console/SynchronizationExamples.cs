using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Console
{
    public class SynchronizationExamples
    {
        private static readonly Semaphore _semaphore = new Semaphore(2, 2);
        private static readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);
        private static readonly ManualResetEvent _manualResetEvent = new ManualResetEvent(false);
        private static readonly object _lockObject = new object();

        public static void RunLockExample()
        {
            lock (_lockObject)
            {
                System.Console.WriteLine("Locked section executed by " + Thread.CurrentThread.ManagedThreadId);
            }
        }

        public static async Task RunSemaphoreExampleAsync()
        {
            _semaphore.WaitOne();
            try
            {
                System.Console.WriteLine($"Semaphore acquired by {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(1000);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public static void RunAutoResetEventExample()
        {
            new Thread(() =>
            {
                System.Console.WriteLine("Thread waiting for signal...");
                _autoResetEvent.WaitOne();
                System.Console.WriteLine("Thread received signal!");
            }).Start();

            Thread.Sleep(1000);
            _autoResetEvent.Set();
        }

        public static void RunManualResetEventExample()
        {
            new Thread(() =>
            {
                System.Console.WriteLine("Thread waiting for signal...");
                _manualResetEvent.WaitOne();
                System.Console.WriteLine("Thread received signal!");
            }).Start();

            Thread.Sleep(1000);
            _manualResetEvent.Set(); // всі потоки, що чекають, розблокуються
        }
    }
}
