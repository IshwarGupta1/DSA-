import Factory.Factory;
import Factory.IProduct;

public class Main {
    public static void main(String[] args) {

        var animal = new Factory();
        var dog = animal.getAnimal("dog");
        var cat = animal.getAnimal("cat");
        dog.Animal();
        cat.Animal();

    }
}