package org.example;

import org.example.Models.Program;
import org.example.TraceClient;

import java.util.List;

public class TraceService {

    TraceClient traceClient;

    public TraceService(TraceClient traceClient) {
        this.traceClient = traceClient;
    }

    public void getTraces(List<Program> programList, int programId)
    {
        traceClient.getTraces(programList, programId);
    }

    public void addTrace(List<Program> programList, int programId, int TraceId)
    {
        traceClient.addTrace(programList, programId, TraceId);
    }

    public void removeTrace(List<Program> programList, int TraceId)
    {
        traceClient.stopTrace(programList, TraceId);
    }
}
