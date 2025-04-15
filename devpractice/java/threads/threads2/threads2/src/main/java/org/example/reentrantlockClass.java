package org.example;

import java.util.concurrent.locks.ReentrantLock;

public class reentrantlockClass {
    public int cnt=0;
    public static ReentrantLock lock = new ReentrantLock();

    public void increment()
    {
        lock.lock();
        for(int i=0;i<5;i++)
            cnt++;
        System.out.println(cnt);
        lock.unlock();
    }

}
