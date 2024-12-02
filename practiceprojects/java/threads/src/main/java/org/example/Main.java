package org.example;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.*;

public class Main {
    public static void main(String[] args) throws InterruptedException, ExecutionException {
        var t1 = new MyThread1();
        var t2 = new MyThread1();
        t1.start();
        //t1.join(); //if MyThread does not have synchronized(lock) then use join
        t2.start();
        //t2.join();

        ExecutorService executor = Executors.newFixedThreadPool(2); // create with number of threads needed
        var numList = new int[]{1, 2, 3, 4, 5};
        Future<Integer> sum1 = executor.submit(()-> { //perfrom action based on this syntax
            int sum = 0;
            for (int i = 0; i < numList.length / 2; i++)
                sum = sum + numList[i];
            return sum;
        });
        Future<Integer> sum2 = executor.submit(()-> {
            int sum = 0;
            for (int i = numList.length/2; i < numList.length; i++)
                sum = sum + numList[i];
            return sum;
        });
        int res1=sum1.get();
        int res2=sum2.get();
        System.out.println(res1 + res2);
        executor.shutdown();//if we don't do this the executor will not end automatically


        //Runnable Represents a task that can be executed concurrently by a thread. It is typically used for tasks that do not return any result.
                Runnable task = () -> {
            System.out.println("Task is running");
        };
        ExecutorService executor2 = Executors.newSingleThreadExecutor();
        executor2.submit(task);  // Submit the task for execution
        executor2.shutdown();    // Shutdown the executor

        //Callable is used when the task returns a result (of type V) or can throw checked exceptions.
        Callable<Integer> task2 = () -> {
            int sum = 0;
            for (int i = 1; i <= 10; i++) {
                sum += i;
            }
            return sum;  // Returning sum as the result
        };

        //A Callable task is executed by passing it to an ExecutorService, which returns a Future object.
        ExecutorService executor3 = Executors.newSingleThreadExecutor();
        Future<Integer> future2 = executor.submit(task2);  // Submit task and get Future
        Integer result = future2.get();  // Retrieve the result
        executor.shutdown();

        //study producer consumer problem



    }
}

