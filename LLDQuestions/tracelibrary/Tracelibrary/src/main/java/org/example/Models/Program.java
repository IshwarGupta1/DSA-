package org.example.Models;

import java.util.ArrayList;
import java.util.List;

public class Program {
    int ProgramId;
    List<Trace> traceList;

    public List<Trace> getTraceList() {
        return traceList;
    }

    public void setTraceList(List<Trace> traceList) {
        this.traceList = traceList;
    }

    public Program(int programId) {
        ProgramId = programId;
        this.traceList = new ArrayList<>();
    }

    public int getProgramId() {
        return ProgramId;
    }

    public void setProgramId(int programId) {
        ProgramId = programId;
    }

    public void removeTrace()
    {
        for(int i=0;i<this.traceList.size();i++)
        {
            long diff = System.currentTimeMillis() - this.traceList.get(i).getTimeSpan();
            if(diff > 100000)
                traceList.remove(this.traceList.get(i));
        }
    }
}
