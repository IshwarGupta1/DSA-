package org.example;

public class MyThread1 extends Thread {

    public int count = 0;
    private static final Object lock = new Object();
    @Override
    public void run()
    {
        synchronized (lock)
        {
            for(int i=0;i<5;i++) {
                count++;
                System.out.println("new count is " + count + " "+Thread.currentThread().getName());
            }
        }
    }
}
