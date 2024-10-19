import javax.xml.crypto.dsig.keyinfo.PGPData;

public class Main {
    public static void main(String[] args) {
        var decorator = new WeatherStations();
        var observer1 = new Phone();
        var observer2 = new Computer();
        decorator.attach(observer1);
        decorator.attach(observer2);
        decorator.setLatestNews("Weather is rainy");
        decorator.attach(observer1);
        decorator.setLatestNews("Weather is clear");

    }
}