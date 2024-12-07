package org.example;

import org.example.Models.*;

import java.util.*;

public class TraceClient {
    public void getTraces(List<Program> programList, int programId)
    {
        Optional<Program> program = programList.stream().filter(program1 -> program1.getProgramId()==programId).findFirst();
        if(program!=null)
            throw new RuntimeException("program not available");
        List<Trace> traceList = program.get().getTraceList();
        traceList.stream().forEach(System.out::println);
    }

    public void stopTrace(List<Program> programList, int TraceId)
    {
        programList.stream()
                .flatMap(program -> program.getTraceList().stream()) // Flatten the nested list structure
                .filter(traceItem -> traceItem.getTraceId() == TraceId) // Match the condition
                .findFirst() // Find the first match
                .ifPresent(traceItem -> { // If a match is found, remove it
                    Trace trace = new Trace(traceItem.getTraceId(), traceItem.getTimeSpan());
                    programList.forEach(program -> program.getTraceList().remove(trace));
                });
    }

    public void addTrace(List<Program> programList, int programId, int TraceId)
    {
        long span = System.currentTimeMillis();
        programList.stream()
                .filter(program -> program.getProgramId() == programId) // Filter for the specific program
                .findFirst() // Find the first matching program
                .ifPresent(program -> program.getTraceList().add(new Trace(TraceId, span)));
    }
}
