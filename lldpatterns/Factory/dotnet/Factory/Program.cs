using Factory;

class Program
{
    static void Main(string[] args)
    {
        var animal = new FactoryAnimal();
        var dog = animal.IdentifyAnimal("dog");
        var cat = animal.IdentifyAnimal("cat");
        dog.Animal();
        cat.Animal();

    }
}