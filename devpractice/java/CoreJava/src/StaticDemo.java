import static java.lang.Math.*; // Static import example

public class StaticDemo {

    // Static variable (shared among all instances)
    static int staticCounter = 0;

    // Instance variable (unique to each object)
    int instanceCounter = 0;

    // Static block (executes once when class is loaded)
    static {
        System.out.println("Static block executed first!");
    }

    // Constructor
    StaticDemo() {
        staticCounter++;
        instanceCounter++;
        System.out.println("Constructor called!");
        System.out.println("Static Counter: " + staticCounter);
        System.out.println("Instance Counter: " + instanceCounter);
    }

    // Static method
    static void staticMethod() {
        System.out.println("Inside static method.");
        System.out.println("Static Counter: " + staticCounter);
        // Can't access instanceCounter directly here
    }

    // Non-static method
    void instanceMethod() {
        System.out.println("Inside instance method.");
        System.out.println("Static Counter: " + staticCounter);
        System.out.println("Instance Counter: " + instanceCounter);
    }

    // Static nested class
    static class StaticNestedClass {
        void display() {
            System.out.println("Inside static nested class.");
            System.out.println("Can access staticCounter: " + staticCounter);
        }
    }
}