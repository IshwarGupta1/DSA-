// 3️⃣ Hierarchical Inheritance
class Cat extends Animal {
    @Override
    void sound() {
        System.out.println("Cat meows");
    }

    void climb() {
        System.out.println("Cat climbs the tree");
    }
}