package org.example;

import org.example.Models.*;

import java.util.ArrayList;
import java.util.List;

public class TraceController {

    private final TraceService traceService;
    private final List<Program> programList;

    public TraceController() {
        this.traceService = new TraceService(new TraceClient());
        this.programList = new ArrayList<>();
        // Initialize with dummy programs for testing
        this.programList.add(new Program(1));
        this.programList.add(new Program(2));
    }

    public void handleGetTraces(int programId) {
        try {
            traceService.getTraces(programList, programId);
        } catch (RuntimeException e) {
            System.err.println("Error: " + e.getMessage());
        }
    }

    /**
     * Simulates the HTTP POST endpoint to add a trace to a specific program.
     */
    public void handleAddTrace(int programId, int traceId) {
        traceService.addTrace(programList, programId, traceId);
        System.out.println("Trace added successfully.");
    }

    public void handleRemoveTrace(int traceId) {
        traceService.removeTrace(programList, traceId);
        System.out.println("Trace removed successfully.");
    }

    public void simulateControllerActions() {
        System.out.println("\n** Simulating Controller Actions **\n");

        // Simulate adding a trace
        handleAddTrace(1, 101);
        handleAddTrace(2, 102);

        // Simulate retrieving traces
        handleGetTraces(1);

        // Simulate deleting a trace
        handleRemoveTrace(101);

        // Attempt to get traces again to observe change
        handleGetTraces(1);
    }
}
