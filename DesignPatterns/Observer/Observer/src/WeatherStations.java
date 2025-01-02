import java.util.ArrayList;
import java.util.List;

public class WeatherStations implements Decorator{
    public List<Observer> observerList = new ArrayList<>();
    public String message = "";

    public void setLatestNews(String news) {
        this.message = news;
        notifyObservers();
    }

    @Override
    public void attach(Observer observer) {
        observerList.add(observer);
    }

    @Override
    public void detach(Observer observer) {
        observerList.remove(observer);
    }

    @Override
    public void notifyObservers() {
        for(int i=0;i<observerList.size();i++)
            observerList.get(i).update(message);
    }
}
