namespace tp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new WeatherSubject();
            var celsiusObserver = new CelsiusObserver();
            subject.Attach(celsiusObserver);

            var fahrenheitObserver = new FahrenheitObserver();
            subject.Attach(fahrenheitObserver);
            
            var kelvinObserver = new KelvinObserver();
            subject.Attach(kelvinObserver);

            var moyenneObserver = new MoyenneObserver();
            subject.Attach(moyenneObserver);
            
            var roundObserver = new RoundObserver();
            subject.Attach(roundObserver);
            
            double temperature;
            bool tempValide;
            while (true)
            {
                Console.Write("Enter temperature en Celsius (avec ,) : ");
                do
                {
                    tempValide = double.TryParse(Console.ReadLine(), out temperature);
                    if (!tempValide)
                    {
                        Console.Write("Rentrez une temperature valide : ");
                    }
                } while (!tempValide);
                subject.ChangeTemperature(temperature);
            }
        }
    }
}