public interface Decorator {
    public void attach(Observer observer);
    public void detach(Observer observer);
    public void notifyObservers();
}
