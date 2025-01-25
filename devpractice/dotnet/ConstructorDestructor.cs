using System;
					
public class Program
{
    public static void Main()
    {
        var prac1 = new practice();
        var prac2 = new practice();
        var prac3 = new practice();
        
        Console.WriteLine("Before GC: " + practice.Cnt); // Should print 3
        
        prac1 = null;  // Dereference the objects
        prac2 = null;
        prac3 = null;

        // Force garbage collection
        GC.Collect();
        GC.WaitForPendingFinalizers();
        
        Console.WriteLine("After GC: " + practice.Cnt); // Should print 0 if destructors are called
    }
}

public class practice
{
    static int cnt = 0;

    public practice()
    {
        cnt++;
    }

    // Destructor to decrement cnt when object is garbage collected
    ~practice()
    {
        cnt--;
    }

    public static int Cnt
    {
        get { return cnt; }
    }
}

