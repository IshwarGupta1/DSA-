package org.example;

import org.example.RateLimiter;

public class RateLimiterFactory {
    public static RateLimiter createRateLimiter(String type, int maxRequests, long windowSizeInMillis) {
        switch (type.toLowerCase()) {
            case "fixed":
                return new FixedWindowRateLimiter(maxRequests, (int) windowSizeInMillis);
            case "sliding":
                return new SlidingWindowRateLimiter(maxRequests, windowSizeInMillis);
            default:
                throw new IllegalArgumentException("Unknown rate limiter type");
        }
    }
}
