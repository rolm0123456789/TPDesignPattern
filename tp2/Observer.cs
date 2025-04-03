namespace tp2;

public interface IObserver
{
    void Update(ISubject subject);
}

public interface ISubject
{
    void Attach(IObserver observer);

    void Detach(IObserver observer);

    void Notify();
}

public class WeatherSubject : ISubject
{
    public double Tempreature { get; set; }

    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine("Subject: Detached an observer.");
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }

    public void ChangeTemperature(double temperature)
    {
        Tempreature = temperature;
        Notify();
    }
}

class CelsiusObserver : IObserver
{
    public void Update(ISubject subject)
    {
        if (subject is WeatherSubject weatherSubject)
        {
            Console.WriteLine("Temperature en Celsius : "+weatherSubject.Tempreature);
        }
    }
}

class FahrenheitObserver : IObserver
{
    public void Update(ISubject subject)
    {
        if (subject is WeatherSubject weatherSubject)
        {
            ContextConverter convert = new ContextConverter(new FahrenheitStrategy());
            Console.WriteLine("Temperature en Fahrenheit : "+convert.ConvertTemperature(weatherSubject.Tempreature));
        }
    }
}

class KelvinObserver : IObserver
{
    public void Update(ISubject subject)
    {
        if (subject is WeatherSubject weatherSubject)
        {
            ContextConverter convert = new ContextConverter(new KelvinStrategy());
            Console.WriteLine("Temperature en Kelvin : "+convert.ConvertTemperature(weatherSubject.Tempreature));
        }
    }
}

class RoundObserver : IObserver
{
    public void Update(ISubject subject)
    {
        if (subject is WeatherSubject weatherSubject)
        {
            ContextConverter convert = new ContextConverter(new RoundStrategy());
            Console.WriteLine("Temperature arroundi : "+convert.ConvertTemperature(weatherSubject.Tempreature));
        }
    }
}

class MoyenneObserver : IObserver
{
    List<double> temperatures = new List<double>();

    public void Update(ISubject subject)
    {
        if (subject is WeatherSubject weatherSubject)
        {
            if (temperatures.Count >= 3)
            {
                temperatures.RemoveAt(0);
            }

            temperatures.Add(weatherSubject.Tempreature);
            Console.WriteLine($"Moyenne des températures : {temperatures.Average()}");
        }
    }
}