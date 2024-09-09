package Factory;

public class Factory {
    public IProduct getAnimal(String animal)
    {
        if(animal=="dog")
            return new Concrete1();
        return new Concrete2();
    }
}
