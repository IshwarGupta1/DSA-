package org.example;

public class RunThread implements Runnable{
    int cnt;
    public RunThread(int cnt)
    {
        this.cnt = cnt;
    }
    @Override
    public void run() {
        for(int i=0;i<5;i++)
        {
            cnt++;
            System.out.println("Runnable " + cnt);
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
        }

    }
}
