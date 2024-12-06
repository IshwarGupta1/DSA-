package org.example;

import java.util.HashMap;

public class FixedWindowRateLimiter implements RateLimiter{
    int maxRequests;
    int duration;
    HashMap<String, Long> requestDuration;
    HashMap<String, Integer> numberofRequests;

    public FixedWindowRateLimiter(int maxRequests, int duration) {
        this.maxRequests = maxRequests;
        this.duration = duration;
        this.requestDuration = new HashMap<>();
        this.numberofRequests = new HashMap<>();
    }

    @Override
    public boolean processRequest(String ClientName) {
        long currentTime = System.currentTimeMillis();

        //check if client is happened ever or not
        if(!requestDuration.containsKey(ClientName))
        {
            requestDuration.put(ClientName, currentTime);
            numberofRequests.put(ClientName, 1);
            return true;
        }
        else {
            long startTime = requestDuration.get(ClientName);
            long timePassed = currentTime - startTime;
            // update for new request
            if(timePassed>=duration)
            {
                requestDuration.put(ClientName, currentTime);
                numberofRequests.put(ClientName, 1);
                return true;
            }
            else
            {
                //if limit reached
                if(numberofRequests.get(ClientName)+1 > maxRequests)
                {
                    return false;
                }
                //limit not reached
                else
                {
                    numberofRequests.put(ClientName, numberofRequests.get(ClientName) + 1);
                    return true;
                }
            }
        }
    }
}
