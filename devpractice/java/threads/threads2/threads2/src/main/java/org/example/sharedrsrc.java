package org.example;

public class sharedrsrc implements Runnable{
    private int cnt=0;
    @Override
    public void run() {
        increment();
    }
    public synchronized void increment()
    {
        for(int i=0;i<5;i++)
        {
            cnt++;
        }
        System.out.println(cnt);
    }
}
