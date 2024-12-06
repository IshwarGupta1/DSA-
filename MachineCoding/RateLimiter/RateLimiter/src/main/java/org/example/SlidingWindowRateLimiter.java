package org.example;

import java.util.*;

public class SlidingWindowRateLimiter implements RateLimiter{

    int maxRequests;
    long windowSizeInMillis;
    Map<String, Queue<Long>> requestTimestamps;

    public SlidingWindowRateLimiter(int maxRequests, long windowSizeInMillis) {
        this.maxRequests = maxRequests;
        this.windowSizeInMillis = windowSizeInMillis;
        this.requestTimestamps = new HashMap<>();
    }

    @Override
    public boolean processRequest(String ClientName) {
        long currentTime = System.currentTimeMillis();
        if(!requestTimestamps.containsKey(ClientName))
        {
            requestTimestamps.put(ClientName, new LinkedList<Long>() {
            });
            return true;
        }
        Queue<Long> timestamps = requestTimestamps.get(ClientName);
        while(timestamps.size()>0&&currentTime-timestamps.peek()>windowSizeInMillis)
            timestamps.poll();
        if (timestamps.size() < maxRequests) {
            timestamps.add(currentTime);
            return true;
        }
        return false;
    }
}
