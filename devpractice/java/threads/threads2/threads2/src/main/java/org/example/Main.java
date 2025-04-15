package org.example;

import java.lang.reflect.Executable;
import java.util.concurrent.Executor;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Main {
    public static void main(String[] args) {
        var src = new sharedrsrc();
        var t1 = new Thread(src);
        var t2 = new Thread(src);
        t1.start();
        t2.start();
        bank b = new bank();
        var t3 = new Thread(()->b.withdraw(2000),"User1");
        var t4 = new Thread(()->b.withdraw(5000), "User2");
        var t5 = new Thread(()->b.withdraw(4000), "User2");
        t3.start();
        t4.start();
        t5.start();
        reentrantlockClass rb = new reentrantlockClass();
        var t6 = new Thread(()->rb.increment(),"User1");
        var t7 = new Thread(()->rb.increment(), "User2");
        t6.start();
        t7.start();
        ExecutorService ex = Executors.newFixedThreadPool(5);
        for(int i=0;i<5;i++)
        {
            ex.execute((Runnable) new reentrantlockClass2());
        }
        ex.shutdown();
    }
}