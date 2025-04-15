package org.example;

public class threadThread extends Thread{
    int cnt;
    public threadThread(int cnt)
    {
        this.cnt = cnt;
    }

    @Override
    public void run() {
        for(int i=0;i<5;i++) {
            cnt++;
            System.out.println("thread " + cnt);
            try {
                Thread.sleep(3000);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
        }
    }
}
