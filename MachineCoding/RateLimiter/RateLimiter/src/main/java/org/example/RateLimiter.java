package org.example;

public interface RateLimiter {
    public boolean processRequest(String ClientName);
}
