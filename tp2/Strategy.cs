using System;

namespace tp2
{
    class ContextConverter
    {
        private ITemperatureConversionStrategy _strategy;

        public ContextConverter(ITemperatureConversionStrategy? strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(ITemperatureConversionStrategy strategy)
        {
            _strategy = strategy;
        }

        public double ConvertTemperature(double temperature)
        {
            return _strategy.Convert(temperature);
        }
    }

    // Interface pour les stratégies de conversion
    public interface ITemperatureConversionStrategy
    {
        double Convert(double temperature);
    }

    // Stratégie de conversion en Fahrenheit
    class FahrenheitStrategy : ITemperatureConversionStrategy
    {
        public double Convert(double temperature)
        {
            return (temperature * 9 / 5) + 32;
        }
    }

    // Stratégie de conversion en Kelvin
    class KelvinStrategy : ITemperatureConversionStrategy
    {
        public double Convert(double temperature)
        {
            return temperature + 273.15;
        }
    }

    class RoundStrategy : ITemperatureConversionStrategy
    {
        public double Convert(double temperature)
        {
            return Math.Round(temperature);
        }
    }
}