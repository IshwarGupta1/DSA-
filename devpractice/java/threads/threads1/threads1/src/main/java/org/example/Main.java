package org.example;

public class Main {
    public static void main(String[] args) {
        var t1 = new threadThread(1);
        t1.start();
        Thread t2 = new Thread(new RunThread(1));
        t2.start();
    }
}