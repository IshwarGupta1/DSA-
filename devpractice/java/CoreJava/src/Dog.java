// 1️⃣ Method Overriding + Multi-level Inheritance
class Dog extends Animal {
    // Overriding method
    @Override
    void sound() {
        System.out.println("Dog barks");
    }

    void guard() {
        System.out.println("Dog guards the house");
    }
}