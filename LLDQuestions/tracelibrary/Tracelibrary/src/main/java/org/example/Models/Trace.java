package org.example.Models;

public class Trace {
    int TraceId;
    long timeSpan;

    public Trace(int traceId, long timeSpan) {
        this.TraceId = traceId;
        this.timeSpan = timeSpan;
    }

    public long getTimeSpan() {
        return timeSpan;
    }

    public void setTimeSpan(long timeSpan) {
        this.timeSpan = timeSpan;
    }

    public int getTraceId() {
        return TraceId;
    }

    public void setTraceId(int traceId) {
        TraceId = traceId;
    }
}
