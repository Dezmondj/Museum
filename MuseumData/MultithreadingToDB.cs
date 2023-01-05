using Microsoft.EntityFrameworkCore;
using MuseumDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumData
{
    public class MultithreadingToDB
    {
        private bool acquiredLock = false;
        private AutoResetEvent waitHandler = new AutoResetEvent(true);
        private Mutex mutex = new Mutex();
        private Semaphore semaphore = new Semaphore(0, 1);
        private DbContextOptions options;
        public MultithreadingToDB(DbContextOptions options)
        {
            this.options = options;
        }

        public void LockExample()
        {
            object? locker = new object();

            for (int i = 0; i < 10; i++)
            {
                using (MuseumDBContext context = new MuseumDBContext(options))
                {
                    Thread myThread = new(() =>
                    {
                        lock (locker!)
                        {
                            context.Clients.Add(new Client { FName = "Client " + i });
                            context.SaveChanges();
                        }
                    });
                    myThread.Start();
                }

            }
        }

        public void MonitorExample()
        {
            object? locker = new object();

            for (int i = 0; i < 10; i++)
            {
                using (MuseumDBContext context = new MuseumDBContext(options))
                {
                    Thread myThread = new(() =>
                    {
                        bool acquiredLock = false;
                        try
                        {
                            Monitor.Enter(locker, ref acquiredLock);

                            context.Clients.Add(new Client { FName = "Client " + i });
                            context.SaveChanges();
                        }
                        finally
                        {
                            if (acquiredLock)
                            {
                                Monitor.Exit(locker);
                            }

                        }
                    });
                    myThread.Start();
                }

            }
        }

        public void AutoResetEventExample()
        {
            for (int i = 0; i < 10; i++)
            {
                using (MuseumDBContext context = new MuseumDBContext(options))
                {
                    Thread myThread = new(() =>
                    {
                        waitHandler.WaitOne();
                        context.Clients.Add(new Client { FName = "Client " + i });
                        context.SaveChanges();
                        waitHandler.Set();
                    });
                    myThread.Start();
                }

            }
        }

        public void MutexExample()
        {
            for (int i = 0; i < 10; i++)
            {
                using (MuseumDBContext context = new MuseumDBContext(options))
                {
                    Thread myThread = new(() =>
                    {
                        mutex.WaitOne();
                        context.Clients.Add(new Client { FName = "Client " + i });
                        context.SaveChanges();
                        mutex.ReleaseMutex();
                    });
                    myThread.Start();
                }

            }
        }

        public void SemaphoreExample()
        {
            for (int i = 0; i < 10; i++)
            {
                using (MuseumDBContext context = new MuseumDBContext(options))
                {
                    Thread myThread = new(() =>
                    {
                        semaphore.WaitOne();
                        context.Clients.Add(new Client { FName = "Client " + i });
                        context.SaveChanges();
                        semaphore.Release();
                    });
                    myThread.Start();
                }
            }
        }
    }
}
