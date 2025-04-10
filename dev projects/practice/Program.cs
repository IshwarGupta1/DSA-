// See https://aka.ms/new-console-template for more information
using practice;

Thread t1 = new Thread(lock1.withdraw);
Thread t2 = new Thread(lock1.withdraw);
t1.Start();
t2.Start();
t1.Join();
t2.Join();

Thread t3 = new Thread(Semaphorelock.goWashroom);
Thread t4 = new Thread(Semaphorelock.goWashroom);
t3.Start();
t4.Start();
t3.Join();
t4.Join();